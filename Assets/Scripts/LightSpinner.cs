﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpinner : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, 1f * Time.deltaTime, Space.World);
	}
}
