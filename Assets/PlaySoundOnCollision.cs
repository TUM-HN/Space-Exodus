using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The script comparte the tag of object on collision and play specified audioclip
 * The code reference from the video online: https://www.youtube.com/watch?v=lBTtzqfaNdM
 */

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
