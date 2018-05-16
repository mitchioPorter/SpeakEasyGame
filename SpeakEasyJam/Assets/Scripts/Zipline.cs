using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zipline : MonoBehaviour {
	public GameObject Startpoint;
	public GameObject grabbingPoint;
	public GameObject endpoint;
	public float grabbingDistance = 3;
	PlayerController player;
	bool sliding = false;
	public float distancePercent;
	float distance;
	float timeStarted;
	float startDist;
	float endDist;
	float lastJumped;
	// Use this for initialization
	void Start () {
		grabbingPoint.transform.rotation = Quaternion.identity;
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		startDist = Vector3.Distance (player.transform.position, Startpoint.transform.position);
		endDist = Vector3.Distance (player.transform.position, endpoint.transform.position); 
		distancePercent = startDist / (endDist + startDist);
		//Debug.Log (distancePercent);
		grabbingPoint.transform.position = Vector3.Lerp (Startpoint.transform.position, endpoint.transform.position, distancePercent);

		if (!sliding && Vector3.Distance (player.transform.position, endpoint.transform.position) > 3 && Time.time > lastJumped+ 2) {
			if (Vector3.Distance (player.transform.position, grabbingPoint.transform.position) < grabbingDistance) {
				startSliding ();
			}
		} else if(sliding) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				stopSliding ();
			}
			distance = Vector3.Distance (player.transform.position, endpoint.transform.position);
			player.transform.position = Vector3.Lerp(player.transform.position, endpoint.transform.position, (Time.time-timeStarted)/(timeStarted*(distance/10)));

			if (Vector3.Distance (grabbingPoint.transform.position, endpoint.transform.position) < grabbingDistance*2) {
				stopSliding ();
			}
		}
		
	}

	void startSliding(){
		sliding = true;
		player.canMove = false;
		player.transform.position = grabbingPoint.transform.position;
		timeStarted = Time.time;
		player.GetComponent<Rigidbody> ().isKinematic = true;
	}

	void stopSliding(){
		sliding = false;
		player.GetComponent<Rigidbody> ().isKinematic = false;
		player.canMove = true;
		lastJumped = Time.time+1;
	}
}

