using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MessRecycle : MonoBehaviour
{

    [SerializeField]
    List<GameObject> bricksContainer;

    [SerializeField]
    List<GameObject> bottles;

    public UnityEvent<GameObject> onEnterEvent;

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
