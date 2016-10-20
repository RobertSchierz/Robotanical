using UnityEngine;
using System.Collections;

public class AddItem : MonoBehaviour {

	[SerializeField]
	private ItemDatabase iDatabase;
	public GameObject pressE;


	void Update () {
		
		//Ray ray = transform.position;
		RaycastHit hit;

		Vector3 forwardPlayer = transform.TransformDirection (Vector3.forward);
		Debug.DrawRay (transform.position, forwardPlayer * 2, Color.red);

		if (Physics.Raycast (transform.position, forwardPlayer, out hit, 2)) {
			pressE.SetActive (true);

			if (Input.GetButton ("Aufheben")) {
				foreach (Item i in iDatabase.InventoryDat) {

					if (i.itemName == hit.collider.tag) {
						i.itemAmount += 1;
						Destroy (hit.collider.gameObject);

					}
				}
			}


		} else {
			pressE.SetActive (false);
		}
			

	}
}
