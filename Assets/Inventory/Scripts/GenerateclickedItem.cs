using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityStandardAssets.Vehicles.Ball;

public class GenerateclickedItem : MonoBehaviour {

	public GameObject player;
	public Transform playertransform;
	public Transform planttransform;
	public bool plantmodisactiv;
	private GameObject plantbase;
	public float plantbaseYOffset = 0.3f;
	public bool bluePrintCollides;
	public GameObject InventoryDatabase;

	// Use this for initialization
	void Start () {
		playertransform = player.transform;
		plantmodisactiv = false;
		bluePrintCollides = false;
		InventoryDatabase = GameObject.Find ("InventoryDatabase");
	}


	
	// Update is called once per frame
	void Update () {
		
		if(plantmodisactiv){
			//Debug.DrawRay (planttransform.position, Vector3.down * 100, Color.blue, Mathf.Infinity);


			if(Input.GetButtonDown ("Submitblueprint") && !bluePrintCollides){
				Debug.Log ("Blueprint gesetzt");
				plantmodisactiv = false;
				plantbase.GetComponent <OnTriggerblueprint>().thisBlueprintIsSet = true;
                Rigidbody plantbaseRigidbody =  (Rigidbody)plantbase.AddComponent<Rigidbody>();
                plantbaseRigidbody.isKinematic = true;
                plantbaseRigidbody.useGravity = false;

				foreach(Item i in InventoryDatabase.GetComponent <ItemDatabase>().InventoryDat){
					//Temporäre Lösung bis PlantDatabase funktioniert
					if(i.itemName.Equals (plantbase.name.Split ('_')[0])){
						i.itemAmount--;
					
					}
				}

			}else{
				updatePlantBlueprint ();
			}

		}

	}

	public void onClickButton(Item i) {

		plantmodisactiv = true;

		InventorySystem inventorysystemscript = (InventorySystem)GameObject.Find ("InventorySystem").GetComponent (typeof(InventorySystem));
		inventorysystemscript.DeactivateInventory ();
		inventorysystemscript.isActive = false;


		plantbase = Instantiate(Resources.Load("Plantbase")) as GameObject;
		plantbase.name = i.itemName + "_plant";
		planttransform = plantbase.transform;

		//Wurde ersetzt weil diese Elemente nicht mehr über das Script generiert werden sondern über prefab
		/*BoxCollider plantbaseBoxCollider = (BoxCollider)plantbase.AddComponent <BoxCollider>();
		plantbaseBoxCollider.size = new Vector3 (2 , 1 , 2);
		plantbaseBoxCollider.isTrigger = true;
		plantbase.AddComponent <OnTriggerblueprint>();*/


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
