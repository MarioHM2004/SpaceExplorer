using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem meteorParticles;

    public LayerMask layerMask;
    public Transform firePoint;
    public float distance = 10;

    private bool rayActive = false;

    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => FireMeteor());
        grabInteractable.deactivated.AddListener(z => StopMeteor());
    }

    public void FireMeteor()
    {
        AudioManager.instance.Play("Gun");
        meteorParticles.Play();
        rayActive = true;
    }

    public void StopMeteor()
    {
        AudioManager.instance.Stop("Gun");
        meteorParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActive = true;
    }

    void Update()
    {
        if (rayActive) {
            RaycastCheck();
        }
    }

    void RaycastCheck()
{
        bool hasHit = Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hit, distance, layerMask);

        if (hasHit) {
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}

