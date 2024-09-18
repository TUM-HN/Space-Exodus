using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * The Breakable class sets a parent object containing child objects to an inactive state while simultaneously activating its child objects. 
 * This class also breaks the parent-child relationship to prevent child objects from inheriting the inactive state of the parent. 
 * This is crucial for ensuring that child objects remain active in the game environment
 * The source code is from the following YouTube video: https://www.youtube.com/watch?v=YBQ_ps6e71k
 */

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
