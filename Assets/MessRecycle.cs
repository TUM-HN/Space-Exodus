using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessRecycle : MonoBehaviour
{

    [SerializeField]
    List<GameObject> bricksContainer;

    [SerializeField]
    List<GameObject> bottles;

    void Update()
    {
        if (bricksContainer.TrueForAll(CheckContainer))
        {
            foreach (GameObject bottle in bottles) bottle.SetActive(true);
        }
    }

    private bool CheckContainer(GameObject container) {
        return container.GetComponentInChildren<checkEmpty>().Collected();
    }
}
