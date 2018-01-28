using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cthullu : MonoBehaviour {


	public static cthullu Instance;

	static bool initialized = false;

	public float speed = 0.5f;
	public Vector3 target;
	public GameObject pos;

	public GameObject[] targets;
	public int wanderIndex;

	private int pathIndex = 0;

	private int pathDirection = 1;


	void Awake() {
		if (!initialized) {
			initialized = true;
			Instance = this;
		}
	}

	void Start () {
		wanderIndex = Random.Range (0, targets.Length);
		target = transform.position;
	}

	void Update () {
		FindTarget ();
		ProcessMotion ();
		//Wander ();
		CurvePath();
	}  

	void ProcessMotion(){
		target = targets[wanderIndex].transform.position;
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}

	void CurvePath(){
		target = targets[wanderIndex].transform.position;
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		if (transform.position.x == targets[wanderIndex].transform.position.x && transform.position.y == targets[wanderIndex].transform.position.y){
			pathIndex += pathDirection;
			if(wanderIndex <= 0 || wanderIndex >= targets.Length){
				wanderIndex = Random.Range(0,targets.Length);
				Debug.Log (wanderIndex);
			}
		}
	}

	void FindTarget(){
		Wander();
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
		target = targets[wanderIndex].transform.position;
		//if (cthulluX >= targetsX && cthulluY >= pt targetsY) {
		if (transform.position.x >= targets[wanderIndex].transform.position.x && transform.position.y >= targets[wanderIndex].transform.position.y ) {
			wanderIndex = Random.Range(0,targets.Length);
			Debug.Log (wanderIndex);
		}
	}
}
