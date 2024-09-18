using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.State;

//This class can let XRInterrableAffordacneStateProvider find the element(XRBaseInterable)
//This is a helper class from tutorial online: https://www.youtube.com/watch?v=YBQ_ps6e71k

public class AutoFindInteractableAffordance : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<XRInteractableAffordanceStateProvider>().interactableSource = GetComponentInParent<XRBaseInteractable>();
    }
}
