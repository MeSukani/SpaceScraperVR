using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SpaceMovement : MonoBehaviour
{
    public XRLever lever;
    public XRKnob knob;

    public float forwardSpeed;
    public float sideMove;
    private bool wasOn;

    void Update()
    {
        float forwardVelocity = forwardSpeed * (lever.value ? 1 : 0);
        float sideVelocity = sideMove * (lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, knob.value);

        Vector3 velocity = new Vector3 (sideVelocity, 0, forwardVelocity);
        transform.position += velocity * Time.deltaTime;

        if (lever.value != wasOn)
        {
             if (lever.value)
            {
                AudioManager.instance.Play("Engine");
            }
            else
            {
                AudioManager.instance.Stop("Engine");
            }
        }
        wasOn = lever.value;
    }
}
