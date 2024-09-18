using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*
 * ButtonPushDoor controls the door by pushing a button. 
 * The door has a Game Object called Animator.
 * This script will be attached to the button. 
 * When the button is pushed (selected), it will trigger the ToggleDoorOpen function. 
 * ToggleDoorOpen will call the Animator and set its boolName to true. 
 * This will play the animation to open the door and then trigger a countdown to close the door after a specified time.
 * 
 * The code in this section is adapted from the YouTube video: https://www.youtube.com/watch?v=YBQ_ps6e71k
 */

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
