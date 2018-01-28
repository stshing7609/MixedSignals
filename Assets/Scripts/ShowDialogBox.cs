using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialogBox : MonoBehaviour {

	public bool success;
	public GameObject dialogbox;

	void Update () {
		if (success) {
			dialogbox.SetActive (true);
		} else {
			dialogbox.SetActive (false);
		}
	}
}
