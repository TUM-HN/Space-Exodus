using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This block acts on the bricks room container. 
 * It checks the trigger zone to verify if the brick placed into the container matches the container's color. 
 * If so, it sets the brick to inactive, plays a success sound, and registers it in a list. 
 * When all containers need to confirm they have their respective bricks, collected() will be called.
 */

public class checkEmpty : MonoBehaviour
{
    private List<GameObject> bricks;

    public string brickcolour;
    public int numberOfBricks; //public parameter -> here can customised how much corresponding bricks should be put in to its container
    public AudioSource audioSource; 
    public AudioClip audioClip; // success sound can also be customised

    private void Start()
    {
        bricks = new List<GameObject>();
        GetComponent<TriggerZone>().onEnterEvent.AddListener(Register);
    }

    private void Register(GameObject brick)
    {
        if (brick.name.ToLower().Contains(brickcolour)) // colour match?
        {
            brick.SetActive(false);
            bricks.Add(brick);
            audioSource.PlayOneShot(audioClip);
        }
    }

    public bool Collected() {
        return bricks.Count == numberOfBricks;
    }
}
