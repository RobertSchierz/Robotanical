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
    public GameObject player;


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

        saveImportantVariables();
        binaryformattersave.Serialize (file, saveslot);
       

        file.Close ();



	}

    public void saveImportantVariables()
    {
            saveslot.playerPosition[0] = (float)player.transform.position.x;
            saveslot.playerPosition[1] = (float)player.transform.position.y;
            saveslot.playerPosition[2] = (float)player.transform.position.z;
            Debug.Log("Saved: " + new Vector3(saveslot.playerPosition[0], saveslot.playerPosition[1], saveslot.playerPosition[2]));
     
        
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
            loadImportantVariables();

        }
	

	
	}

    public void loadImportantVariables()
    {
        Debug.Log("Loaded: " + new Vector3(saveslot.playerPosition[0], saveslot.playerPosition[1], saveslot.playerPosition[2]));
        player.transform.position =  new Vector3(saveslot.playerPosition[0], saveslot.playerPosition[1], saveslot.playerPosition[2]);
    }

}


[Serializable]
public class Saveobject
{


	public List<SaveInventoryItem> inventoryItemList = new List<SaveInventoryItem> ();
    public float[] playerPosition = new float[3];

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