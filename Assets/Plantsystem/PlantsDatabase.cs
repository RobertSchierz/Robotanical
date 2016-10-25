using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Security.Cryptography.X509Certificates;



public class PlantsDatabase : MonoBehaviour {
	public List<Plant> PlantsDat = new List<Plant>();

	void Start(){
		foreach(Plant p in PlantsDat){
			p.plantName = PlayerPrefs.GetString (p.plantName);
			p.plantType = PlayerPrefs.GetString (p.plantType);
		}


	}
		
}
