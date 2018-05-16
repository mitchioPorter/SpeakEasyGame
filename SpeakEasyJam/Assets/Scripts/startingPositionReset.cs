using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingPositionReset : MonoBehaviour {
	Vector3 startingPos;
	public float delaySpawn = 0;
	public float currentTime;
	bool eventTriggered = false;
	Quaternion startingRotation;

	// Use this for initialization
	void Start () {
		currentTime = delaySpawn;
		startingPos = transform.position;
		startingRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -20 && !eventTriggered) {
			eventTriggered = true;
			currentTime = delaySpawn;
		} 
		else if (eventTriggered && currentTime <= 0.0f) {
			GetComponent<Rigidbody> ().velocity = new Vector3(0,0,0);
			transform.position = startingPos;
			transform.rotation = startingRotation;
			eventTriggered = false;
		} 
		else if (eventTriggered) {
			currentTime -= Time.deltaTime;
		}
	}
}
