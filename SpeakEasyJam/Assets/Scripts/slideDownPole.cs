using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideDownPole : MonoBehaviour {
	public GameObject startingPoint;
	public GameObject endingPoint;
	public GameObject minimumHeight;
	float distance;
	PlayerController player;
	float timeStarted;
	bool sliding = false;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y < startingPoint.transform.position.y && player.transform.position.y > minimumHeight.transform.position.y && !sliding && player.transform.parent == null) {
			if (Mathf.Sqrt(Mathf.Pow(Mathf.Abs (player.transform.position.x - transform.position.x),2) + Mathf.Pow(Mathf.Abs (player.transform.position.z - transform.position.z),2)) < 2) {
				sliding = true;
				player.canMove = false;
				player.transform.position = new Vector3 (startingPoint.transform.position.x, player.transform.position.y, startingPoint.transform.position.z);
				timeStarted = Time.time;
			}

		}
	if(sliding){
			distance = Mathf.Abs (player.transform.position.y - endingPoint.transform.position.y);

			player.transform.position = Vector3.Lerp(player.transform.position, endingPoint.transform.position, ((Time.time-timeStarted)/(timeStarted * distance)) );
			Debug.Log ((Time.time-timeStarted)/(timeStarted* distance) );
			if (player.transform.position.y <= endingPoint.transform.position.y) {
				sliding = false;
				player.canMove = true;
			}
		}
	}
}
