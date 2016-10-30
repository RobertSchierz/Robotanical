using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class TriggerMenuButtons : MonoBehaviour {
	public GameObject SaveLoadSystem;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void triggerWeiterButton(){
		GetComponent <Menusystem>().isActive = !GetComponent <Menusystem>().isActive; 
		GetComponent <Menusystem>().DeactivateMenu (); 
	}

	public void triggerSpeichernButton(){

		Savesystem.savesystem.saveGame ();
		Debug.Log ("Inventorylist saved at: " + Application.persistentDataPath + "/gameInfo.dat");
	}
}
