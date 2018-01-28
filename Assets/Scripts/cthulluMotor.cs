using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cthulluMotor : MonoBehaviour {

	public static cthulluMotor Instance;

	public float speed = 1.5f;
	public Vector3 target;
	public GameObject pos;

	public GameObject[] targets;

	private int pathIndex = 0;

	private int pathDirection = 1;


	void Awake() {
		Instance = this;
	}

	void Start () {
		target = transform.position;
	}

	void Update () {
		ProcessMotion ();
	}  

	void ProcessMotion(){
		target = pos.transform.position;
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}

	void CurvePath(){
		target = targets[pathIndex].transform.position;
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		if (transform.position.x >= targets[pathIndex].transform.position.x && transform.position.y >= targets[pathIndex].transform.position.y){
			pathIndex += pathDirection;
			if(pathIndex <= 0 || pathIndex >= targets.Length){
				
			}
		}
	}
}
