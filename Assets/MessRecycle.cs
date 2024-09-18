using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * This script, like checkempty, is designed to operate on containers for brick recycling. 
 * However, this script goes a step further by ensuring that all containers meet 
 * their specific brick recycling quotas through the CheckContainer() function.
 */

public class MessRecycle : MonoBehaviour
{

    [SerializeField]
    List<GameObject> bricksContainer;

    [SerializeField]
    List<GameObject> bottles;

    public UnityEvent<GameObject> onEnterEvent;

    //Update is called per frame. When all containers have their tageted number of bricks recycled, candies instead of bottles are shown.
    void Update()
    {
        if (bricksContainer.TrueForAll(CheckContainer))
        {
            foreach (GameObject bottle in bottles) bottle.SetActive(true);
            onEnterEvent.Invoke(gameObject);
        }
    }

    private bool CheckContainer(GameObject container) {
        return container.GetComponentInChildren<checkEmpty>().Collected();
    }
}
