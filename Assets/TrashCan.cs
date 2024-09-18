using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The trashcan is designed to interact with the trigger zone (a separate script). 
 * Upon activation of the trigger zone, signifying that an object has entered the trashcan's collision area, 
 * the object will be destroyed and a sound cue will be played.
 * 
 * The source code reference form the following yt video: https://www.youtube.com/watch?v=YBQ_ps6e71k
 */

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
