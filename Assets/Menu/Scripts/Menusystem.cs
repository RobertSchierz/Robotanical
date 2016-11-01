using UnityEngine;
using System.Collections;

public class Menusystem : MonoBehaviour {


	public GameObject MenuPanel;
	[SerializeField]
	public bool isActive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetButtonDown ("Menu")){

			isActive = !isActive;

		}

		if(isActive){
			ActivateMenu ();
			GameObject.Find ("InventorySystem").GetComponent <InventorySystem> ().isActive = false;

		}

		if(!isActive){
			DeactivateMenu ();

		}
	}

	public void ActivateMenu(){

		if(MenuPanel.activeSelf == false){
			MenuPanel.SetActive ( true );
			Cursor.visible = true;
			Time.timeScale = 0;
			GameObject.Find ("Camera").GetComponent <ThirdPersonCamera>().enabled = false;

		}

	}

	public void DeactivateMenu(){

		if(MenuPanel.activeSelf == true){
			MenuPanel.SetActive ( false );
			Cursor.visible = false;
			Time.timeScale = 1;
			GameObject.Find ("Camera").GetComponent <ThirdPersonCamera>().enabled = true;

		}
	}
}
