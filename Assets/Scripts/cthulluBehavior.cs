﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cthulluBehavior : MonoBehaviour {

	public static cthulluBehavior Instance;

	static bool initialized = false;

	public GameObject[] targets;

	public cthulluMotor cm;

	public int wanderIndex;

	void Awake() {
		if (!initialized) {
			initialized = true;
			Instance = this;
		}
	}

	void Start(){
		wanderIndex = Random.Range (0, targets.Length);

	}

	void Update(){
		FindTarget ();
		Wander ();
	}

	void FindTarget(){
		cm.pos = targets[wanderIndex];
		//if (cthulluX >= targetsX && cthulluY >= pt targetsY) {
		if (cm.transform.position.x >= targets[wanderIndex].transform.position.x && cm.transform.position.y >= targets[wanderIndex].transform.position.y ) {
			wanderIndex = Random.Range(0,targets.Length);
			Debug.Log (wanderIndex);
		}
	}

	float Distance(Vector3 pt1, Vector3 pt2) {
		return Mathf.Sqrt(Mathf.Pow((pt2.x-pt1.x),2) + Mathf.Pow((pt2.y-pt1.y),2));
	}

	void TargetPowerUp() {
	}

	void TargetWinningTeam(){
		
	}

	void TargetClosetTeam(){
		
	}

	void TargetTeamWithSmallestDistance(){
		//Vector3.Distance(other.position, transform.position);

	}

	Vector3 GetMidPoint(Vector3 pos1, Vector3 pos2, float offset)
	{

		Vector3 dir = (pos2 - pos1).normalized ;
		Vector3 perpDir = Vector3.Cross(dir, Vector3.right) ;

		Vector3 midPoint = (pos1 + pos2) / 2f ;

		Vector3 offsetPoint = midPoint + (perpDir * offset) ;

		return offsetPoint ;
	}

	void Wander() {
		cm.pos = targets[wanderIndex];
		//if (cthulluX >= targetsX && cthulluY >= pt targetsY) {
		if (cm.transform.position.x >= targets[wanderIndex].transform.position.x && cm.transform.position.y >= targets[wanderIndex].transform.position.y ) {
			wanderIndex = Random.Range(0,targets.Length);
			Debug.Log (wanderIndex);
		}
	}

}
