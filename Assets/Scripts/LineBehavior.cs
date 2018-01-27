using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehavior : MonoBehaviour {
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
	}
}
