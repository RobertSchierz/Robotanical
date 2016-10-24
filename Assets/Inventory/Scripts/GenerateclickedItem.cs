﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.VersionControl;

public class GenerateclickedItem : MonoBehaviour {

	public GameObject player;
	public Transform playertransform;
	public Transform planttransform;
	private bool plantmodisactiv;
	private GameObject plantbase;
	public float plantbaseYOffset = 0.3f;

	// Use this for initialization
	void Start () {
		playertransform = player.transform;
		plantmodisactiv = false;
	}


	
	// Update is called once per frame
	void LateUpdate () {
		if(plantmodisactiv){
			//Debug.DrawRay (planttransform.position, Vector3.down * 100, Color.blue, Mathf.Infinity);

			updatePlantBlueprint ();

		}

	}

	public void onClickButton(Item i) {

		plantmodisactiv = true;

		InventorySystem inventorysystemscript = (InventorySystem)GameObject.Find ("InventorySystem").GetComponent (typeof(InventorySystem));
		inventorysystemscript.DeactivateInventory ();
		inventorysystemscript.isActive = false;

		plantbase = Instantiate(Resources.Load("Plantbase")) as GameObject;
		planttransform = plantbase.transform;
		BoxCollider plantbaseBoxCollider = (BoxCollider)plantbase.AddComponent <BoxCollider>();
		plantbaseBoxCollider.size = new Vector3 (2 , 1 , 2);
		plantbaseBoxCollider.isTrigger = true;
		plantbase.AddComponent <OnTriggerblueprint>();




	}

	public void updatePlantBlueprint(){
		

		planttransform.Translate (0 ,100.0f, 0);
		RaycastHit hitInfo;

		Ray ray = new Ray (planttransform.position, Vector3.down);

		bool isHit = Physics.Raycast (ray, out hitInfo, Mathf.Infinity);

		if(isHit){

			Quaternion rotation = Quaternion.Euler(0 ,playertransform.localEulerAngles.y, 0); 
			Vector3 plantbaseposition = playertransform.position + rotation * new Vector3 (0, 0, 5);
			planttransform.position = new Vector3 (plantbaseposition.x, hitInfo.point.y, plantbaseposition.z);


		}

			
	}

	public void blueprintOnTriggerEnter(Material invalidBlueprintMaterial){
		planttransform.GetChild (0).GetComponent <Renderer>().material = invalidBlueprintMaterial;
	}

	public void blueprintOnTriggerLeave(Material validBlueprintMaterial){
		planttransform.GetChild (0).GetComponent <Renderer>().material = validBlueprintMaterial;
	}


}
