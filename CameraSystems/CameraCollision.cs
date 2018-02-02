//Created and Developed by Kieren Hovasapian (C) 2018 - Filmstorm
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//How to use
//Create an empty game object, call it "CameraBase" and then add the component - "Camera Follow" to it.
//Create another empty game object and parent/place it on the hips/pelvis bone of your character/player
//Then parent the MainCamera to this object and apply the "CameraCollision" to the camera. 

[AddComponentMenu("Filmstorm/Camera Collision")]
public class CameraCollision : MonoBehaviour {

	public float minDistance = 1.0f;
	public float maxDistance = 5.0f;
	public float smooth = 10.0f;
	Vector3 dollyDir;
	public Vector3 dollyDirAdjusted;
	public float distance;

	// Use this for initialization
	void Awake () {
		dollyDir = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 desiredCameraPos = transform.parent.TransformPoint (dollyDir * maxDistance);
		RaycastHit hit;

		if (Physics.Linecast (transform.parent.position, desiredCameraPos, out hit)) {
			distance = Mathf.Clamp ((hit.distance * 0.87f), minDistance, maxDistance);
				
				} else {
					distance = maxDistance;
				}

				transform.localPosition = Vector3.Lerp (transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
	}
}
