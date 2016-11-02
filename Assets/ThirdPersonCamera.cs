using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.Cameras;

public class ThirdPersonCamera : MonoBehaviour {

	// Y Adjustierung der Camera + Minimal & Maximal Faktor für Veränderung beim Zoom
	public float yAngleMin = 25.0f;
	private const float MAX_YANGLE_MIN = 45.0f;
	private const float MIN_YANGLE_MIN = 25.0f;
	private float yAAngleMax = 70.0f;

	// Sensitivität der Mausbewegung
	private const float MOUSE_SENSITIVITY = 1.5f;
	private const float MOUSE_SENSITIVITX = 1.5f;

	public Transform lookAt; 
	public Transform camTransform;
	private float playerStartXRotation;

	private GameObject player;

	public float distance = 11.0f; 
	private float nextDistance;
	public float distanceZoomSpeed = 5.0f;
	private float minDistance = 7.0f;
	private float maxDistance = 16.0f;
	private float distanceTreshold = 8.0f;

	private Vector3 lookAtPoint = new Vector3(0.0f, 0.0f, 0.0f);
	public float lookAtHeight = 4.0f;
	private const float MIN_LOOKAT_HEIGHT = 4.0f;
	private const float MAX_LOOKAT_HEIGHT = 5.0f;

	public float currentX = 0.0f;
	public float currentY = 0.0f; 
	public float sensivetyX = 4.0f; 
	public float sensivetyY = 4.0f;

	private Camera cam; 




	// Use this for initialization
	void Start () {
		camTransform = transform; 
		cam = Camera.main;

		player = GameObject.Find ("Humanoid");
		lookAt = player.transform;
		playerStartXRotation = lookAt.transform.rotation.eulerAngles.y;

		nextDistance = distance;




	}

	private void Update(){
		currentX += Input.GetAxis ("Mouse X") * MOUSE_SENSITIVITX;
		currentY += Input.GetAxis ("Mouse Y") * MOUSE_SENSITIVITY;

		if(Input.GetAxis ("Mouse X") != 0){

			lookAt.transform.rotation = Quaternion.Euler(lookAt.eulerAngles.x,playerStartXRotation + currentX,lookAt.eulerAngles.z);
		}

		if(Input.GetAxis("Mouse ScrollWheel") < 0 ){
			nextDistance++;
		}else if(Input.GetAxis("Mouse ScrollWheel") > 0 ){
			nextDistance--;
		}

		distance = Mathf.Clamp (distance, minDistance, maxDistance);
		nextDistance = Mathf.Clamp (nextDistance,minDistance, maxDistance);
		lookAtHeight = Mathf.Clamp (lookAtHeight, MIN_LOOKAT_HEIGHT, MAX_LOOKAT_HEIGHT);
		yAngleMin = Mathf.Clamp (yAngleMin, MIN_YANGLE_MIN, MAX_YANGLE_MIN);
	
		currentY = Mathf.Clamp (currentY, yAngleMin, yAAngleMax);
	}
	

	void LateUpdate () { 
		Vector3 dir = new Vector3(0,0,-distance); 
		Quaternion rotation = Quaternion.Euler(currentY,currentX, 0); 
		camTransform.position = lookAt.position + rotation * dir; 

		lookAtPoint.y = lookAtHeight;
		camTransform.LookAt (lookAt.position + lookAtPoint);

		if(distance != nextDistance){
			if(distance < nextDistance){
				distance = distance + (Time.deltaTime * distanceZoomSpeed); 
			}
			if(distance > nextDistance){
				distance = distance - (Time.deltaTime * distanceZoomSpeed); 
			}
		}

		// Um beim zoomen die Lookatheight & y Winkel anzupassen (Usability)
		if (distance <= distanceTreshold) {
			lookAtHeight += Time.deltaTime * 1.2f;
			yAngleMin += Time.deltaTime * 15.0f;

			// Time.deltaTime Differenz aufheben
			if(lookAtHeight > MAX_LOOKAT_HEIGHT){
				lookAtHeight = MAX_LOOKAT_HEIGHT;
			}

			// Time.deltaTime Differenz aufheben
			if(yAngleMin > MAX_YANGLE_MIN){
				yAngleMin = MAX_YANGLE_MIN;
			}


		} else {
			lookAtHeight -= Time.deltaTime * 1.2f;
			yAngleMin -= Time.deltaTime * 15.0f;

			// Time.deltaTime Differenz aufheben
			if(lookAtHeight < MIN_LOOKAT_HEIGHT){
				lookAtHeight = MIN_LOOKAT_HEIGHT;
			}

			// Time.deltaTime Differenz aufheben
			if(yAngleMin < MIN_YANGLE_MIN){
				yAngleMin = MIN_YANGLE_MIN;
			}
		}

	
	}
}
