using UnityEngine;
using System.Collections;
using  UnityStandardAssets.Utility;
using UnityStandardAssets.Vehicles.Car;
using System.Collections.Generic;
public class IntantiateCar : MonoBehaviour {
	public List< GameObject> CarsList;

	public Transform PosInicial;
	public Transform PosInicialAI;
	public SmoothFollow cameraSm;



	void Start () {
		
		//Car Player
		int Rand= Random.Range (0, CarsList.Count);

		GameObject carInst =	CarsList [Rand];
		CarsList.Remove (carInst);
		carInst.SetActive (true);
		carInst.transform.position= PosInicial.position;
		cameraSm.target = carInst.transform;
		carInst.GetComponent <WaypointProgressTracker> ().enabled = false;
		carInst.GetComponent <CarAIControl> ().enabled = false;
		carInst.GetComponent <CarUserControl> ().enabled = true;

		// Set Active car AI
		GameObject carAI =	CarsList [Random.Range (0,CarsList.Count)];
		carAI.GetComponent <CarAIControl>().m_Driving=true;
		carAI.transform.position= PosInicialAI.position;
	}
	

}
