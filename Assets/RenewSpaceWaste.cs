using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenewSpaceWaste : MonoBehaviour
{
    public List<GameObject> Meteors;
    float count;

    void Start()
    {
        foreach (var meteor in Meteors) {
            meteor.SetActive(true);
        }
        count = Meteors.Count;
    }

    private void ResetMeteor()
    {
        foreach (var meteor in Meteors) {
            meteor.SetActive(true);
        }
        count = Meteors.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            StartCoroutine(Coroutine());
        }
    }

    public void TargetCount() {
        count--;
    }

    private IEnumerator Coroutine() {
        yield return new WaitForSeconds(1.5f);
        ResetMeteor();
    }
}
