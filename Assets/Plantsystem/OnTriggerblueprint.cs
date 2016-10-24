using UnityEngine;
using System.Collections;

public class OnTriggerblueprint : MonoBehaviour {
	public Material invalidBlueprintMaterial;
	public Material validBlueprintMaterial;
	private GameObject InventoryDatabase;
	private GenerateclickedItem generateitemscript;
	private string collidername;

	// Use this for initialization
	void Start () {
		invalidBlueprintMaterial = Resources.Load ("InvalidMaterialBlueprint", typeof(Material)) as Material;
		validBlueprintMaterial = Resources.Load ("ValidMaterialBlueprint", typeof(Material)) as Material;
		InventoryDatabase = GameObject.Find ("InventoryDatabase");
		generateitemscript = (GenerateclickedItem)InventoryDatabase.GetComponent (typeof(GenerateclickedItem));
		collidername = "";
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Checkt ob mit dem Blueprint etwas berührt wurde und setzt Material
	void OnTriggerEnter(Collider collider){
		collidername = collider.name;
		generateitemscript.blueprintOnTriggerEnter ( invalidBlueprintMaterial); 

	}

	// Checkt ob der berührte Collider verlassen wurde und setzt Material zurück
	void OnTriggerExit(Collider collider){
		if(collider.name.Equals (collidername)){
			generateitemscript.blueprintOnTriggerEnter ( validBlueprintMaterial); 
		}



	}


}
