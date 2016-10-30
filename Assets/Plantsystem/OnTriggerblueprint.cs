using UnityEngine;
using System.Collections;

public class OnTriggerblueprint : MonoBehaviour {
	public Material invalidBlueprintMaterial;
	public Material validBlueprintMaterial;
	private GameObject InventoryDatabase;
	private GenerateclickedItem generateitemscript;
	private string collidername;
	public bool thisBlueprintIsSet;

	// Use this for initialization
	void Start () {

		//Wurde ersetzt weil diese Elemente nicht mehr über das Script generiert werden sondern über prefab
		//invalidBlueprintMaterial = Resources.Load ("InvalidMaterialBlueprint", typeof(Material)) as Material;
		//validBlueprintMaterial = Resources.Load ("ValidMaterialBlueprint", typeof(Material)) as Material;

		InventoryDatabase = GameObject.Find ("InventoryDatabase");
		generateitemscript = InventoryDatabase.GetComponent <GenerateclickedItem>();
		collidername = "";
		thisBlueprintIsSet = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Checkt ob mit dem Blueprint etwas berührt wurde und setzt Material
	void OnTriggerEnter(Collider collider){
		if(!thisBlueprintIsSet){
			collidername = collider.name;
			generateitemscript.blueprintOnTriggerEnter ( invalidBlueprintMaterial); 
			generateitemscript.bluePrintCollides = true;
		}

	}
		


	// Checkt ob der berührte Collider verlassen wurde und setzt Material zurück
	void OnTriggerExit(Collider collider){
		if (!thisBlueprintIsSet) {
			if (collider.name.Equals (collidername)) {
				generateitemscript.blueprintOnTriggerEnter (validBlueprintMaterial); 
				generateitemscript.bluePrintCollides = false;
			}
		}



	}


}
