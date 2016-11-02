using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]

public class Item {
    public int plantnumber;
	public string itemName;
	public int itemAmount;
	public GameObject itemSlot;
	public Text itemAmountT;



	public Item(string iName, int iAmount, GameObject iSlot, Text iAmountT, int iPlantNumber){

        iPlantNumber = plantnumber;
		iName = itemName;
		iAmount = itemAmount;
		iSlot = itemSlot;
		iAmountT.text = itemAmountT.ToString ();

	}
}
