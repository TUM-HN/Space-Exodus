using UnityEngine;
using System.Collections;

public class ColorPicker : MonoBehaviour {
	public Color[] color;
	public bool colochange; //Change color in time
	public float TimeToChangeColor=2;

	void Awake(){
		

		if(colochange)
			InvokeRepeating ("ColorChange", 1, TimeToChangeColor);
		else
			GetComponent<Renderer> ().material.color=color[Random.Range(0,color.Length)] ;
		
	}

	// Use this for initialization
	void ColorChange () {
		GetComponent<Renderer> ().material.color=color[Random.Range(0,color.Length)] ;

	}

}
