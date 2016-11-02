using UnityEngine;
using System.Collections;
using System;


[Serializable]
public class SaveInventoryItem  {

    public int itemPlantNumber;
	public string itemName;
	public int itemAmount;

	public SaveInventoryItem(string iName, int iAmount, int iplantNumber){

        itemPlantNumber = iplantNumber;
		itemName = iName;
		itemAmount = iAmount;
	}

}
