using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEnv : MonoBehaviour
{
    public GameObject env;
    public AudioClip audioClip;
    public AudioSource audioSource;

    public void ResetMeteorsPosition()
    {
        env.transform.position = new Vector3(36.66112f, -62.85889f, -87.8f);
        env.transform.rotation = new Quaternion(0, 0, 0, 0);

        audioSource.PlayOneShot(audioClip);
    }
}
