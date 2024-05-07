using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketTagInteractor : XRSocketInteractor
{
    public string targetTag;

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && targetTag == interactable.transform.tag;
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && targetTag == interactable.transform.tag;
    }
}
