using UnityEngine;
using System.Collections;
using UnityEditor;

public class InventorySystem : MonoBehaviour {

	public GameObject InventoryPanel;
	[SerializeField]
	public bool isActive;
	

	void Update () {

		if(Input.GetButtonDown ("Inventory")){

			isActive = !isActive;

		}

		if(isActive){
			ActivateInventory ();
		}

		if(!isActive){
			DeactivateInventory ();
		}
	}

	public void ActivateInventory(){

		if(InventoryPanel.activeSelf == false){
			InventoryPanel.SetActive ( true );
			Cursor.visible = true;
            GameObject.Find("Camera").GetComponent<ThirdPersonCamera>().enabled = false;
        }

	}

	public void DeactivateInventory(){

		if(InventoryPanel.activeSelf == true){
			InventoryPanel.SetActive ( false );
			Cursor.visible = false;
            GameObject.Find("Camera").GetComponent<ThirdPersonCamera>().enabled = true;
        }
	}
}
