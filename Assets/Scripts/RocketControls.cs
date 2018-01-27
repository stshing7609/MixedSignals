using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControls : MonoBehaviour {
	public float thrust = 10; // forward/backward force multiplier
	public float torque = 1; // torque multiplier
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
	rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetMovement ();
	}
	void GetMovement() {
		if (Input.GetButton("Vertical")) {
			rb.AddRelativeForce (Vector2.up * thrust * Input.GetAxis("Vertical"));
		}
		if (Input.GetButton ("Horizontal")) {
			rb.AddTorque (torque * -1 * Input.GetAxis ("Horizontal"));
		}

	}
}
