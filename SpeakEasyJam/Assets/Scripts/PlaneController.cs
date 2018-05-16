using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {
	public float rotateSpeed = 1;
	public float baseSpeed = 6;
	public float activateDistance = 3;
	public GameObject driverSeat;

	public Material defaultOff;
	public Material defaultOn;
	MeshRenderer mshRndr;
	Quaternion startingRotation;
	public bool canMove = false;
	Rigidbody rigidBody;
	Vector3 startingPosition;


	public PlayerController player;

	// Use this for initialization
	void Start () {
		mshRndr = GetComponent<MeshRenderer> ();
		rigidBody = GetComponent<Rigidbody> ();
		startingPosition = transform.position;
		startingRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -15) {
			player.transform.parent = null;
			canMove = false;
			player.canMove = true;
			player.GetComponent<CapsuleCollider> ().enabled = true;
	
			player.GetComponent<Rigidbody> ().isKinematic = false;

		}
		if (canMove && Input.GetKeyDown (KeyCode.E)) {
			exitCar ();
		}
		else if (Vector3.Distance (player.transform.position, transform.position) <= activateDistance) {
			if (!canMove && Input.GetKeyDown (KeyCode.E)) {
				transform.rotation = startingRotation;
				enterCar ();
			}
		}

		if (canMove) {
			if (Input.GetKey (KeyCode.Space)) {
				transform.Translate (0, 0, -1 * baseSpeed);
			}
			if (Vector3.Distance (player.transform.position, transform.position) > 1) {
				player.transform.position = transform.position;
			}
			var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
			var z = Input.GetAxis ("Vertical") * Time.deltaTime * 150.0f;

			transform.Rotate (0, x * rotateSpeed, 0);
			transform.Rotate (-z * rotateSpeed, 0, 0);
		} else {
			mshRndr.material = defaultOff;
		}
	}

	void enterCar(){
		mshRndr.material = defaultOn;
		player.transform.position = driverSeat.transform.position;
		player.canMove = false;
		canMove = true;
		player.transform.parent = driverSeat.transform;
		player.transform.rotation = driverSeat.transform.rotation;

		/*player.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		player.GetComponent<Rigidbody> ().useGravity = false;
		player.GetComponent<Rigidbody> ().detectCollisions = false;
		player.GetComponent<Rigidbody> ().freezeRotation = true;
		*/
		player.GetComponent<Rigidbody> ().isKinematic = true;
		player.GetComponent<CapsuleCollider> ().enabled = false;


	}


	void exitCar(){
		canMove = false;
		player.canMove = true;
		player.transform.position = new Vector3(transform.position.x,transform.position.y + 1, transform.position.z);
		player.transform.parent = null;
		Vector3 eulerRotation = new Vector3(player.startingRotation.eulerAngles.x, player.transform.eulerAngles.y, player.startingRotation.eulerAngles.z);
		player.transform.rotation = Quaternion.Euler(eulerRotation);
		player.GetComponent<CapsuleCollider> ().enabled = true;
		/*player.GetComponent<Rigidbody> ().useGravity = true;
		player.GetComponent<Rigidbody> ().detectCollisions = true;
		*/
		player.GetComponent<Rigidbody> ().isKinematic = false;


	}
}
