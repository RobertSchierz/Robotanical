using UnityEngine;
using System.Collections;
using System;


[Serializable]
public class SaveInventoryItem  {

	public string itemName;
	public int itemAmount;

	public SaveInventoryItem(string iName, int iAmount){

		itemName = iName;
		itemAmount = iAmount;
	}

}
