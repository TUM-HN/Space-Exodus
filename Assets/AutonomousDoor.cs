using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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
        animator.SetBool(boolName, !isOpen);

        if (animator.GetBool(boolName)) StartCoroutine(coroutine());
    }

    private IEnumerator coroutine() {
        yield return new WaitForSeconds(3);
        AudioManager.instance.Play("Door");
        animator.SetBool(boolName, false);
    }
}
