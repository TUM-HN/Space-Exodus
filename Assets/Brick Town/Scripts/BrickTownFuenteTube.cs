using UnityEngine;
using System.Collections;

public class BrickTownFuenteTube : MonoBehaviour {
	public GameObject[] legoPiezas;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("bricksInsPartes",0,0.1f);
	}
	
	// Update is called once per frame
	void bricksInsPartes () {
		Instantiate (legoPiezas[Random.Range(0,4)],this.transform.position, Quaternion.identity);
	}
}
