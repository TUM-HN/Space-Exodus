using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*
 * This script, triggered by the "grab" button, can hide the hand that is in contact with an object. 
 * At the start, there are two listeners, one for when the selection starts and another for when it ends.
 * 
 * The source code is referenced from the follwing yt video: https://www.youtube.com/watch?v=YBQ_ps6e71k
 */

public class DisabledGrabbingHandModel : MonoBehaviour
{
    public GameObject rightHandModel;
    public GameObject leftHandModel;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);
    }

    // When the selection starts, it checks whether it's the left or right hand and sets the model of that hand to inactive
    public void HideGrabbingHand(SelectEnterEventArgs args) {
        if (args.interactorObject.transform.tag == "Left Hand")
        {
            leftHandModel.SetActive(false);
        }
        else if (args.interactorObject.transform.tag == "Right Hand") {
            rightHandModel.SetActive(false);
        }
    }

    // When the selection ends, it checks again and sets the model of that hand to active
    public void ShowGrabbingHand(SelectExitEventArgs args) {
        if (args.interactorObject.transform.tag == "Left Hand")
        {
            leftHandModel.SetActive(true);
        }
        else if (args.interactorObject.transform.tag == "Right Hand")
        {
            rightHandModel.SetActive(true);
        }
    }
}
