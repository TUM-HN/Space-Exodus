using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkEmpty : MonoBehaviour
{
    private List<GameObject> bricks;

    public string brickcolour;
    public int numberOfBricks;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        bricks = new List<GameObject>();
        GetComponent<TriggerZone>().onEnterEvent.AddListener(Register);
    }

    private void Register(GameObject brick)
    {
        if (brick.name.ToLower().Contains(brickcolour))
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
