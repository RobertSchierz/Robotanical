using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

[Serializable]
public class ItemDatabase : MonoBehaviour {

	public GameObject savesystem;
	public Saveobject saveobject;
	//public List<Item> InventoryDat;
	//private ItemDatabase itemDatabase;
	public List<Item> InventoryDat = new List<Item> ();
	void Start(){



		saveobject = savesystem.GetComponent <Savesystem> ().load ();
		//InventoryDat = saveobject.inventoryItemList;
	

		//if(InventoryDat != null){
			foreach(Item i in InventoryDat){
			Savesystem.savedInventoryList.Add (i);

				//i.itemAmount = Savesystem.savesystem.getInt (i.itemName, itemDatabase);

				//i.itemAmount = PlayerPrefs.GetInt (i.itemName);

			//i.itemAmount = savesystem.GetComponent <Savesystem> ().getInt (i.itemName, saveobject.inventoryItemList);

				Item tempitem = i;
				i.itemSlot.GetComponent <Button>().onClick.AddListener (() => OnItemClick(tempitem));


			}
	//	}



		//Savesystem.savesystem.saveInventoryDatabase (new ItemDatabase());
	}

	public void OnItemClick(Item item){

		//Gamobject test = GetComponents (GenerateclickedItem).onClickButton(item);
		GenerateclickedItem generateitemscript = (GenerateclickedItem)GetComponent (typeof(GenerateclickedItem));
		generateitemscript.onClickButton (item);
	}



	void FixedUpdate(){


			foreach (Item i in InventoryDat) {


				i.itemAmountT.text = i.itemAmount.ToString ();
				if (i.itemAmount > 0) {
					i.itemSlot.SetActive (true);
				} else {
					i.itemSlot.SetActive (false);
				}
				
		/*	if(i.itemAmount != Savesystem.getValue (i.itemName)){
				Savesystem.addValue (i.itemName, i.itemAmount);
				print ("Saved: "+i.itemName);
			}*/


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
