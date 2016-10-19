using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ItemDatabase : MonoBehaviour {
	public List<Item> InventoryDat = new List<Item>();

	void Start(){
		foreach(Item i in InventoryDat){
			i.itemAmount = PlayerPrefs.GetInt (i.itemName);
		}


	}

	void FixedUpdate(){

		foreach(Item i in InventoryDat){


			i.itemAmountT.text = i.itemAmount.ToString ();
			if (i.itemAmount > 0) {
				i.itemSlot.SetActive (true);
			} else {
				i.itemSlot.SetActive ( false );
			}
			if(i.itemAmount != PlayerPrefs.GetInt (i.itemName)){
				PlayerPrefs.SetInt (i.itemName, i.itemAmount);
				print ("Saved: "+i.itemName);
			}

		}

	}
}
