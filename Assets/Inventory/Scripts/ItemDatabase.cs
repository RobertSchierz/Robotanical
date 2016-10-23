using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Security.Cryptography.X509Certificates;


public class ItemDatabase : MonoBehaviour {
	public List<Item> InventoryDat = new List<Item>();

	void Start(){
		foreach(Item i in InventoryDat){
			i.itemAmount = PlayerPrefs.GetInt (i.itemName);
			Item tempitem = i;
			i.itemSlot.GetComponent <Button>().onClick.AddListener (() => OnItemClick(tempitem));


		}


	}

	public void OnItemClick(Item item){

		//Gamobject test = GetComponents (GenerateclickedItem).onClickButton(item);
		GenerateclickedItem generateitemscript = (GenerateclickedItem)GetComponent (typeof(GenerateclickedItem));
		generateitemscript.onClickButton (item);
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
