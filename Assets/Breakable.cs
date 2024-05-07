using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Breakable : MonoBehaviour
{
    public List<GameObject> breakablePieces;
    public float timeToBreak = 3;
    public float timer = 0;
    public UnityEvent OnBreak;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in breakablePieces) item.SetActive(false);
    }

    public void Break()
    {
        timer += Time.deltaTime;

        if (timer <= timeToBreak) return;

        foreach (var item in breakablePieces)
        {
            item.SetActive(true);
            item.transform.parent = null; //disable after line 23 if not set parent null
        }

        OnBreak.Invoke();
        gameObject.SetActive(false);
    }
}
