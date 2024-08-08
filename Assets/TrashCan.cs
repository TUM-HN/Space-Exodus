using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    private void Start()
    {
        GetComponent<TriggerZone>().onEnterEvent.AddListener(InsideTrash);
    }

    public void InsideTrash(GameObject go){
        go.SetActive(false);
        audioSource.PlayOneShot(audioClip);
    }
}
