using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControls : MonoBehaviour {
	public float thrust = 10; // forward/backward force multiplier
	public float torque = 1; // torque multiplier
	public float bouncy = 3; // how much the level boundaries bounce the object 

	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
	rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		EnforceBoundaries ();
		GetMovement ();
	}
	void EnforceBoundaries () {
		// Applies an inward force field to the player if they attempt to leave the boundary.
		float x = 8f;
		float y = 4f;
		// TODO: Get height and width of the scene from the camera.
		Vector2 Position = gameObject.transform.position;
		if (Position.x < -1 * x) {
			rb.AddForce (Vector2.right * thrust * bouncy);
		}
		if (Position.x > x) {
			rb.AddForce (Vector2.left * thrust * bouncy);
		}
		if (Position.y > y) {
			rb.AddForce (Vector2.down * thrust * bouncy);
		}
		if (Position.y < -1 * y) {
			rb.AddForce (Vector2.up * thrust * bouncy);
		}
	}
	void GetMovement() {
		// Responds to movement inputs by the player by rotating and or thrusting the rocket.
		if (Input.GetButton("Vertical")) {
			rb.AddRelativeForce (Vector2.up * thrust * Input.GetAxis("Vertical"));
		}
		if (Input.GetButton ("Horizontal")) {
			rb.AddTorque (torque * -1 * Input.GetAxis ("Horizontal"));
		}

	}
}