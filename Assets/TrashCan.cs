using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TriggerZone>().onEnterEvent.AddListener(InsideTrash);
        UnityEngine.Debug.Log("start");
    }

    public void InsideTrash(GameObject go){
        go.SetActive(false);
        UnityEngine.Debug.Log("delete object");
    }
}
