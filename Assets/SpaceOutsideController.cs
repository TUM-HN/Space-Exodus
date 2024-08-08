using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.XR.Content.Interaction;

public class SpaceOutsideController : MonoBehaviour
{
    public UnityEvent<GameObject> onEnterEvent;

    public XRLever lever;
    public XRKnob knob;
    public XRSlider slider;

    public float forwardSpeed;
    public float sideSpeed;
    public float updownSpeed;

    private bool wasOn;
    private IEnumerator coroutine;

    // Update is called once per frame
    void Update()
    {
        float forwardVelocity = forwardSpeed * (lever.value? 1 : 0);
        float sideVelocity = sideSpeed * (lever.value? 1 : 0) * Mathf.Lerp(-1, 1, knob.value);
        float updownVelocity = updownSpeed * (lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, slider.value);
        coroutine = Timer();

        Vector3 vector = new Vector3(sideVelocity, updownVelocity, forwardVelocity);
        transform.position += vector * Time.deltaTime;

        if (wasOn) {
            StartCoroutine(coroutine);
            if (lever.value) AudioManager.instance.Play("Engine");
            else AudioManager.instance.Stop("Engine");
        }

        wasOn = lever.value;
    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(90);
        onEnterEvent.Invoke(lever.gameObject);

    }

    public void ResetCoroutine() {
        StopCoroutine(coroutine);
        lever.value = false;
        wasOn = false;
        knob.value = 0;
        slider.value = 0.5f;

    }
}
