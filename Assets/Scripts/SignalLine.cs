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

        Debug.Log(isConnected());
	}

    bool isConnected()
    {
        Vector3 heading = p2.transform.position - p1.transform.position;
        float dist = heading.magnitude;
        Vector3 direction = heading / dist;

        RaycastHit2D hit = Physics2D.Raycast(p1.transform.position, direction, dist);
         
        if (hit.collider.gameObject.CompareTag(p1.tag))
        {
            return true;
        }

        return false;
    }
}
