using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

[Serializable]
public class ItemDatabase : MonoBehaviour
{


	//public List<Item> InventoryDat;
	//private ItemDatabase itemDatabase;
	public List<Item> InventoryDat = new List<Item> ();

	void Start ()
	{



		Savesystem.savesystem.load ();
		//InventoryDat = saveobject.inventoryItemList;
	

		//if(InventoryDat != null){
		if (Savesystem.savesystem.saveslot.inventoryItemList.Count == 0) {
			foreach (Item i in InventoryDat) {
				SaveInventoryItem tempitem = new SaveInventoryItem (i.itemName , i.itemAmount);
				Savesystem.savesystem.saveslot.inventoryItemList.Add ( tempitem);
				i.itemAmount = 0;

				Item tempitemForListener = i;
				i.itemSlot.GetComponent <Button> ().onClick.AddListener (() => OnItemClick (tempitemForListener));

			}
		} else {

			foreach (Item i in InventoryDat) {
				i.itemAmount = Savesystem.savesystem.saveslot.getInventoryItemValue (i.itemName);

				Item tempitemForListener = i;
				i.itemSlot.GetComponent <Button> ().onClick.AddListener (() => OnItemClick (tempitemForListener));


			}
		}
	}

	public void OnItemClick (Item item)
	{

		//Gamobject test = GetComponents (GenerateclickedItem).onClickButton(item);
		GenerateclickedItem generateitemscript = (GenerateclickedItem)GetComponent (typeof(GenerateclickedItem));
		generateitemscript.onClickButton (item);
	}



	void FixedUpdate ()
	{


		foreach (Item i in InventoryDat) {


			i.itemAmountT.text = i.itemAmount.ToString ();
			if (i.itemAmount > 0) {
				i.itemSlot.SetActive (true);
			} else {
				i.itemSlot.SetActive (false);
			}
				
			if (i.itemAmount != Savesystem.savesystem.saveslot.getInventoryItemValue (i.itemName)) {
				Savesystem.savesystem.saveslot.addInventoryItemValue (i.itemName, i.itemAmount);
				print ("Saved: " + i.itemName);
			}


			/*if(i.itemAmount != Savesystem.savesystem.getInt (i.itemName, itemDatabase)){
				Savesystem.savesystem.saveInventoryDatabase (Savesystem.savesystem.setInt (i.itemName, i.itemAmount, itemDatabase));
				print ("Saved: "+i.itemName);
			}*/

			/*	if(i.itemAmount != PlayerPrefs.GetInt (i.itemName)){
				PlayerPrefs.SetInt (i.itemName, i.itemAmount);
				print ("Saved: "+i.itemName);
			}*/

		}	




	}




}
