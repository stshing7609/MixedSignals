﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour {
	public GameObject source;
	public GameObject target;
	public SignalLine line;
	public float velocity = 2f;
	public float dt = .01f;
	private float time;
	public float epsilon = .02f;
	private bool isLive = false;
	private string otherTeam;

	// Use this for initialization
	void Start () {
		startSignal (source, target);
		getOtherTeam ();
	}
	
	// Update is called once per frame
	void Update () {
		moveSignal ();
	}

	void getUserInput() {
	}

	void startSignal(GameObject s, GameObject t) {
		if (!isLive) {
			time = 50 * dt;
			source = s;
			target = t;
			isLive = true;
		}
	}

	void moveSignal () { 
		if (isLive) {
			transform.position = source.transform.position + getDirection () * velocity * time;
			time += dt;
		}
		if (targetReached() ) {
			Debug.Log("gooooool");
			goooooooool ();
		}
	}

	bool targetReached() {
		// If the signal is further out than the target, it counts as target reached.
		float signalDistance = (transform.position - source.transform.position).magnitude;
		float targetDistance = (target.transform.position - source.transform.position).magnitude;
		return ( (targetDistance -signalDistance) < epsilon);
	}

	Vector3 getDirection () {
		Vector3 difference = target.transform.position - source.transform.position;
		float distance = difference.magnitude;
		return difference / distance;
	}

	void OnCollisionEnter2D (Collision2D col) {
		
		if (col.gameObject.CompareTag (otherTeam)) {
			distort ();
		}
		else if (col.gameObject.CompareTag (target.gameObject.tag) || col.gameObject.CompareTag(source.gameObject.tag)) {
			Debug.Log ("lol");
		}
		else {
			Debug.Log ("Destruction");
			destroy ();
		}
	}

	void goooooooool(){
		// Insert code to update score here
		isLive = false;
		startSignal (target, source);
		//GameObject temp = source;
		//source = target;
		//target = source;
	}

	void destroy() {
		// Insert code to show signal blowing up
		isLive = false;
		startSignal(source, target);
	}

	void distort() {
	}

	void getOtherTeam(){
		switch (source.gameObject.tag) {
		case "Team1":
			otherTeam = "Team2";
			break;
		case "Team2":
			otherTeam = "Team1";
			break;
		}
	}
}
