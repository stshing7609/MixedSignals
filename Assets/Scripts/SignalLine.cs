using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalLine : MonoBehaviour {
    public LineRenderer line;
    public GameObject p1;
    public GameObject p2;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
		line.SetPosition(0, p1.transform.position);
        line.SetPosition(1, p2.transform.position);

		//Debug.Log(isConnected());

	}

//	/// </summary>
//	/// <param name="player">Player.</param>
//	void shootSignal(GameObject player) {
//		// Check if player is the one who can shoot and then shoot.
//		if (whoCanShoot.Equals(player) ) {
//			drawSignal (player);
//			switch (player) {
//			case p1:
//				receiver = p2;
//			case p2:
//				receiver = p1;
//			}			
//			signalIsLive = true;
//		}
//	}
//	void drawSignal() {
//	}
//	void destroySignal() {
//	}
//	void perturbSignal() {
//	}
//	void updateSignalPosition() {
//		signal.transform.position + getDirection (receiver, source) * velocity * dt;
//	}

    bool isConnected()
    {
		
		Vector3 difference = p2.transform.position - p1.transform.position;
		float dist = difference.magnitude;
		Vector3 direction = difference / dist; 

        RaycastHit2D hit = Physics2D.Raycast(p1.transform.position, direction, dist);
         
        if (hit.collider.gameObject.CompareTag(p1.tag))
        {
            return true;
        }

        return false;
    }

	Vector3 getDirection(GameObject a, GameObject b) {
		Vector3 difference = a.transform.position - b.transform.position;
		float dist = difference.magnitude;
		return difference / dist;
	}
}
