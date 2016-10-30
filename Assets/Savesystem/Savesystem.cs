using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

public class Savesystem : MonoBehaviour {
	public static Savesystem savesystem = new Savesystem();
	public static List<Item> savedInventoryList;
	public Saveobject savedobject;

	// Use this for initialization
	void Start () {
		//ItemDatabaseNow = load ();
		savedInventoryList = new List<Item> ();

		if(!File.Exists (Application.persistentDataPath + "/gameInfo.dat")){
			saveGame ();
		}
	
	}

	/*void Awake(){
		if(savesystem == null){
			DontDestroyOnLoad (gameObject);
			savesystem = this;
		}else if( savesystem != this){
			Destroy (gameObject);
		}
	}*/
	
	// Update is called once per frame
	void LateUpdate() {
		
	}


	public void saveGame(){

		savedobject = new Saveobject ();
			
		savedobject.inventoryItemList = savedInventoryList;
			/*foreach(Item i in iBase.GetComponent <ItemDatabase> ().InventoryDat){
			savedobject.inventoryItemList.Add (i);
		}*/

			BinaryFormatter binaryformatter = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/gameInfo.dat");

			binaryformatter.Serialize (file, savedobject);

			file.Close ();



	}

	public Saveobject load(){


			BinaryFormatter binaryformatter = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
		Saveobject saveobject = (Saveobject)binaryformatter.Deserialize (file);

			Debug.Log (Application.persistentDataPath + "/gameInfo.dat");
		file.Close ();
			return saveobject;

	
	}
	/*
	public static void addValue(string name, int itemAmount){
		foreach(Item t in savedInventoryList){
			if(t.itemName.Equals (name)){
				t.itemAmount = itemAmount;
			}
		}
	}

	public static int getValue(string name){
		int itemReturnAmount = 0;
		foreach(Item t in savedInventoryList){
			if (t.itemName.Equals (name)) {
				itemReturnAmount = t.itemAmount;
			}

		}
		return itemReturnAmount;
	}
*/

	/*public int getInt(string key, List<Item> itemdatalist){
		int temp = itemdatalist.Where (item => item.itemName == key).SingleOrDefault ().itemAmount;
		return temp;
	}*/
	

}


[Serializable]
public class Saveobject {


	public List<Item> inventoryItemList;

	/*public Saveobject(List<Item> _inventoryItemList){

		if(_inventoryItemList == null){
			inventoryItemList = new List<Item> ();
		}else{
			inventoryItemList = _inventoryItemList;
		}




}*/	
}