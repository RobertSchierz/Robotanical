using UnityEngine;
using System.Collections;
using UnityEditor;

public class InventorySystem : MonoBehaviour {

	public GameObject InventoryPanel;
	[SerializeField]
	public bool isActive;
	

	void FixedUpdate () {

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
		}

	}

	public void DeactivateInventory(){

		if(InventoryPanel.activeSelf == true){
			InventoryPanel.SetActive ( false );
			Cursor.visible = false;
		}
	}
}
