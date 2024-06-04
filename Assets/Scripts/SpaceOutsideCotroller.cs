using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SpaceOutsideCotroller : MonoBehaviour
{
    public XRLever lever;
    public XRKnob knob;

    public float forwardSpeed;
    public float sideSpeed;
    private bool wasActivated;

    void Update()
    {
        float forwardVelocity = forwardSpeed * (lever.value ? 1 : 0);
        float sideVelocity = sideSpeed * (lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, knob.value);

        Vector3 velocity = new Vector3(sideVelocity, 0, forwardVelocity);
        transform.position += velocity * Time.deltaTime;

        if (lever.value != wasActivated) {
            if (lever.value) {
                AudioManager.instance.Play("SpaceShipEngine");
            } else {
                AudioManager.instance.Stop("SpaceShipEngine");
            }
        }

        wasActivated = lever.value;
    }
}
