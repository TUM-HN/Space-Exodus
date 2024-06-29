using UnityEngine;
using System.Collections;

public class CarroColisiones : MonoBehaviour {
	
	public GameObject []Piezas;
	public CarroColisiones[] car;
	// Use this for initialization
	void Start () {
		//Piezas = GameObject.FindGameObjectsWithTag ("Pieza");
		car = GameObject.FindObjectsOfType<CarroColisiones> ();

	}
	void cargaNivel(){
		Application.LoadLevel (Application.loadedLevelName);
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Explota") {
			Destroy (other.gameObject);
			Destroy (this.gameObject, 5);
			Invoke ("cargaNivel",3);
			//car = GameObject.FindObjectsOfType<CarroColisiones> ();
			foreach (CarroColisiones carcol in car){
			carcol.Explota ();
			}
		}
	}
	
	// Update is called once per frame
	public void Explota () {
		
		foreach(GameObject game in Piezas){
			game.AddComponent<BoxCollider> ().size = new Vector3 (0.3f,0.3f,0.3f);
			if(game.GetComponent <Rigidbody> ()==null){	
			game.AddComponent<Rigidbody> ();
			}
			Destroy (game, 5);
		}
	}
}
