using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*
 *  This script is for an autonomous door system. 
 *  It utilizes a trigger zone component to detect object ingress into a designated area, triggering the openDoor() function 
 *  and subsequently initiating a countdown timer(coroutine()) for automated door closure.
 */

public class AutonomousDoor : MonoBehaviour
{
    public Animator animator;
    private string boolName = "open";

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TriggerZone>().onEnterEvent.AddListener(i => OpenDoor());
    }

    private void OpenDoor() {
        bool isOpen = animator.GetBool(boolName);
        AudioManager.instance.Play("Door");
        animator.SetBool(boolName, !isOpen);

        if (animator.GetBool(boolName)) StartCoroutine(coroutine());
    }

    private IEnumerator coroutine() {
        yield return new WaitForSeconds(3);
        AudioManager.instance.Play("Door");
        animator.SetBool(boolName, false);
    }
}
