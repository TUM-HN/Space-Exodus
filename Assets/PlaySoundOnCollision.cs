using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioclip;

    public string PlayAudioWithTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == PlayAudioWithTag) audioSource.PlayOneShot(audioclip);
    }
}
