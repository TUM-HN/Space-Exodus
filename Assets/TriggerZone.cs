using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * The triggerzone script is the foundation for custom interactions in our game. 
 * It's a simple yet powerful tool that allows you to define specific behaviors based on collisions.
 * 
 * It is reference from the following video: https://www.youtube.com/watch?v=YBQ_ps6e71k
 */

public class TriggerZone : MonoBehaviour
{
    public string targetTag;
    public UnityEvent<GameObject> onEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag) {
            onEnterEvent.Invoke(other.gameObject);
            //UnityEngine.Debug.Log("collision happens");
        }
    }

}
