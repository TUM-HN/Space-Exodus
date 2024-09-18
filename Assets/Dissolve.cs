using UnityEngine;
using UnityEngine.Events;

/*
 * This script handles the destruction of the meteor. 
 * Upon calling the "Break" function, the GameObject associated with this script will be destroyed, 
 * a corresponding sound effect will be triggered, and the Unity event "OnBreak" will be dispatched.
 * 
 * The script reference from the following yt video: https://www.youtube.com/watch?v=YBQ_ps6e71k
 */

public class Dissolve : MonoBehaviour
{
    public UnityEvent OnBreak;

    public void Break() {
        gameObject.SetActive(false);
        AudioManager.instance.Play("Meteor Disappear");
        OnBreak.Invoke();
    }
}
