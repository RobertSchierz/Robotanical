using UnityEngine;
using System.Collections;
using UnityEditor;

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
			Debug.DrawRay (planttransform.position, Vector3.down * 100, Color.blue, Mathf.Infinity);

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
	}

	public void updatePlantBlueprint(){
		

		planttransform.Translate (0 ,100.0f, 0);
		RaycastHit hitInfo;

		Ray ray = new Ray (planttransform.position, Vector3.down);

		bool isHit = Physics.Raycast (ray, out hitInfo, Mathf.Infinity);

		if(isHit){

			//planttransform.position = new Vector3(playertransform.position.x,hitInfo.point.y + plantbaseYOffset ,playertransform.position.z + 2);


			//planttransform.position =  new Vector3(0, hitInfo.point.y + plantbaseYOffset, 0 );

			//planttransform.Translate(Vector3.up * (hitInfo.point.y + plantbaseYOffset), Space.World); 

			//planttransform.rotation = Quaternion.Euler ( new Vector3 (playertransform.rotation.x,0,playertransform.rotation.z));
			//planttransform.RotateAround (player.transform.localPosition,Vector3.up, 20 * Time.deltaTime);


			Quaternion rotation = Quaternion.Euler(0 ,playertransform.localEulerAngles.y, 0); 
			Vector3 plantbasicposition = playertransform.position + rotation * new Vector3 (0, 0, 5);
			planttransform.position = new Vector3 (plantbasicposition.x, hitInfo.point.y, plantbasicposition.z);
			//planttransform.Translate(new Vector3(0,hitInfo.point.y,0), Space.World); 

		

			//camTransform.LookAt (lookAt.position + lookAtPoint);

			Debug.Log (new Vector3(0, hitInfo.point.y,0));
		}
			
	}
}
