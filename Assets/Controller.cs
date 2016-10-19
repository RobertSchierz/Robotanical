using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public GameObject player;
	private Vector3 rotation;
	public float shiftSpeed = 2.0f;


	void Start () {
		Cursor.visible = false;
		rotation = player.transform.rotation.eulerAngles;
	}
	

	void Update () {
		if (Input.anyKey) {
			Vector3 movement = new Vector3( 0, 0, 0) ;

			if (Input.GetKey ("w")) {
				if(Input.GetKey ("a")){
					movement.x = -Time.deltaTime;
				}
				if(Input.GetKey ("d")){
					movement.x = +Time.deltaTime;
				}
				movement.z = +Time.deltaTime;

			}else if(Input.GetKey ("s")){
				if(Input.GetKey ("a")){
					movement.x = -Time.deltaTime;
				}
				if(Input.GetKey ("d")){
					movement.x = +Time.deltaTime;
				}
				movement.z = -Time.deltaTime;

			} else if(Input.GetKey ("a")) {
				movement.x = -Time.deltaTime;

			

			}else if(Input.GetKey ("d")){
				movement.x = +Time.deltaTime;
			}

			if (Input.GetKey ("left shift")) {
				movement = movement * shiftSpeed;
			}

			player.transform.Translate (movement);


		}


			
	}
}
