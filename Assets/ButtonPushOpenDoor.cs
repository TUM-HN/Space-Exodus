using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushOpenDoor : MonoBehaviour
{
    public Animator animator;
    public string boolName = "open";

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ToggleDoorOpen());
    }

    private void ToggleDoorOpen()
    {
        AudioManager.instance.Play("Door");

        bool isOpen = animator.GetBool(boolName);

        animator.SetBool(boolName, !isOpen);
        if (animator.GetBool(boolName)) StartCoroutine(coroutine());

    }

    IEnumerator coroutine() {
        yield return new WaitForSeconds(5);
        AudioManager.instance.Play("Door");
        animator.SetBool(boolName, false);

    }
}
