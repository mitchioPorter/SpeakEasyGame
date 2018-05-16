using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float rotateSpeed = 1;
	public float baseSpeed = 1;
	float moveSpeed = 1;
	public float sprintMultiplier = 2;
	public float crouchMultiplier = .5f;
	public float jumpPower = 10;
	public float sprintJumpMultiplier = 1.5f;

	public float mass;


	bool canJump = true;

	public bool  canMove = true;
	Rigidbody rigidBody;
	bool sprinting;
	bool crouching;
	Vector3 startingPosition;
	public Quaternion startingRotation;
	Vector3 lastJump;
	RaycastHit hit;


	// Use this for initialization
	void Start ()
	{
		moveSpeed = baseSpeed;
		rigidBody = GetComponent<Rigidbody> ();
		startingPosition = transform.position;
		startingRotation = transform.rotation;
		lastJump = startingPosition;
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.contacts.Length > 0) {
			ContactPoint contact = collision.contacts [0];
			if (Vector3.Dot (contact.normal, Vector3.up) > 0.5) {
				canJump = true;
			}
		}
	}



	// Update is called once per frame
	void Update ()
	{
		if (canMove) {
			//moves player depending on axis arrow keys
			var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
			var z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f;

			transform.Rotate (0, x * rotateSpeed, 0);
			transform.Translate (0, 0, z * moveSpeed);

			//jumps if possible
			if (canJump && Input.GetKey (KeyCode.Space)) {
				lastJump = transform.position;
				if (sprinting) {
					rigidBody.AddForce (new Vector3 (0, jumpPower * sprintJumpMultiplier, 0), ForceMode.Impulse);
					canJump = false;
				} else {
					rigidBody.AddForce (new Vector3 (0, jumpPower, 0), ForceMode.Impulse);
					canJump = false;
				}
			}

			//sprint button
			if (Input.GetKey (KeyCode.LeftShift) && canJump) {
				moveSpeed = baseSpeed * sprintMultiplier;
				sprinting = true;
			} 
		//crouching button
		else if (Input.GetKey (KeyCode.LeftAlt)) {
				moveSpeed = baseSpeed * crouchMultiplier;
				crouching = true;
			} else {
				moveSpeed = baseSpeed;
				crouching = false;
				sprinting = false;
			}

			if (transform.position.y < -20) {
				transform.position = lastJump;
				transform.parent = null;
				canMove = true;
			}

			if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.down), .1f)) {
				print ("There is below");
				canJump = true;
			}
		} else {
			rigidBody.freezeRotation = true;
			if (transform.position.y < -20) {
				transform.parent = null;
				transform.position = startingPosition;
				transform.rotation = startingRotation;
				canMove = true;
			}
		}
	}




}
