using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControls : MonoBehaviour {
	public float thrust = 10; // forward/backward force multiplier
	public float torque = 1; // torque multiplier
	public float bouncy = 3; // how much the level boundaries bounce the object 

	public string VerticalString;
	public string HorizontalString;

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

		//Adds screen boundaries
		Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
		pos.x = Mathf.Clamp01(pos.x);
		pos.y = Mathf.Clamp01(pos.y);
		transform.position = Camera.main.ViewportToWorldPoint(pos);

		//Removes bounce
		Vector3 p = Camera.main.WorldToViewportPoint (transform.position);
		pos.x = Mathf.Clamp01(pos.x);
		pos.y = Mathf.Clamp01(pos.y);

		Vector3 speed = rb.velocity;
		if(p.x == 0 || p.x == 1)
			speed.x = 0;
		if(p.y == 0 || p.y == 1)
			speed.y = 0;
		

		transform.position = Camera.main.ViewportToWorldPoint(pos);
		rb.velocity = speed;


		/*
		float x = 8f;
		float y = 4f;
		// TODO: Get height and width of the scene from the camera.
		Vector2 Position = gameObject.transform.position;
		if (Position.x <= -1 * x) {
			rb.AddForce (Vector2.right * thrust * bouncy);
		}
		if (Position.x >= x) {
			rb.AddForce (Vector2.left * thrust * bouncy);
		}
		if (Position.y >= y) {
			rb.AddForce (Vector2.down * thrust * bouncy);
		}
		if (Position.y <= -1 * y) {
			rb.AddForce (Vector2.up * thrust * bouncy);
		}
		*/
	}
	void GetMovement() {
		// Responds to movement inputs by the player by rotating and or thrusting the rocket.
		if (Input.GetButton(VerticalString)) {
			rb.AddRelativeForce (Vector2.up * thrust * Input.GetAxis(VerticalString));
		}
		if (Input.GetButton (HorizontalString)) {
			rb.AddRelativeForce (Vector2.right * thrust * Input.GetAxis(HorizontalString));
		}

	}
}