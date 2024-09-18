using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

/*
 * This script, when attached to a pistol, toggles a Boolean 'rayActive' upon 'select' input, correspondingly activating particle effects and sound. 
 * The 'Update()' function continuously evaluates 'rayActive'. 
 * If true, a raycast is initiated from the weapon along a predefined path. 
 * Upon collision with an object, a "Break" message is dispatched.
 * 
 * The source code is referenced from the following yt video: https://www.youtube.com/watch?v=YBQ_ps6e71k
 */

public class MeteorPistol : MonoBehaviour
{

    public ParticleSystem particles;
    public LayerMask layerMask;
    public Transform shootSource;
    public float distance = 10;

    private bool rayActivate = false;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());
    }

    public void StartShoot() {
        AudioManager.instance.Play("Pistol");
        particles.Play();
        rayActivate = true;
    }

    public void StopShoot() {
        AudioManager.instance.Stop("Pistol");
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rayActivate) RaycastCheck();
    }

    void RaycastCheck() {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, out hit, distance, layerMask);

        if (hasHit) hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
    }
}
