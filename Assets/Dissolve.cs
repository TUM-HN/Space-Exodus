using UnityEngine;
using UnityEngine.Events;

public class Dissolve : MonoBehaviour
{
    public UnityEvent OnBreak;

    public void Break() {
        gameObject.SetActive(false);
        AudioManager.instance.Play("Meteor Disappear");
        OnBreak.Invoke();
    }
}
