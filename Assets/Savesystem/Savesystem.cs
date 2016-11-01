using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

public class Savesystem : MonoBehaviour
{
	public static Savesystem savesystem;
	public Saveobject saveslot;


	void Awake(){

		//ItemDatabaseNow = load ();
		saveslot = new Saveobject ();
		if(savesystem == null){
			savesystem = this;
		}


	/*	if(savesystem == null){
			//DontDestroyOnLoad (gameObject);
			savesystem = this;
		}else if( savesystem != this){
			Destroy (gameObject);
		}
		*/
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		
	}


	public void saveGame ()
	{


		/*foreach(Item i in iBase.GetComponent <ItemDatabase> ().InventoryDat){
			savedobject.inventoryItemList.Add (i);
		}*/

		BinaryFormatter binaryformattersave = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/gameInfo.dat");


		binaryformattersave.Serialize (file, saveslot);

		file.Close ();



	}

	public void load ()
	{


		if (File.Exists (Application.persistentDataPath + "/gameInfo.dat")) {
			BinaryFormatter binaryformatterload = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
			Saveobject saveobject = (Saveobject)binaryformatterload.Deserialize (file);

			Debug.Log (Application.persistentDataPath + "/gameInfo.dat");
			file.Close ();

			saveslot = saveobject;
		}
	

	
	}





	/*public int getInt(string key, List<Item> itemdatalist){
		int temp = itemdatalist.Where (item => item.itemName == key).SingleOrDefault ().itemAmount;
		return temp;
	}*/
	

}


[Serializable]
public class Saveobject
{


	public List<SaveInventoryItem> inventoryItemList = new List<SaveInventoryItem> ();




	public void addInventoryItemValue(string name, int itemAmount){
		foreach(SaveInventoryItem t in inventoryItemList){
			if(t.itemName.Equals (name)){
				t.itemAmount = itemAmount;
			}
		}
	}

	public int getInventoryItemValue(string name){
		int itemReturnAmount = 0;
		foreach(SaveInventoryItem t in inventoryItemList){
			if (t.itemName.Equals (name)) {
				itemReturnAmount = t.itemAmount;
			}

		}
		return itemReturnAmount;
	}








}