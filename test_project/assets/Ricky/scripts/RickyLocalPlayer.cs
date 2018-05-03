using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class RickyLocalPlayer : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {
			GetComponent<RigidbodyFirstPersonController> ().enabled = true;
			GetComponentInChildren<Camera> ().enabled = true;
			GetComponent<MouseLook> ().XSensitivity = 2;
			GetComponent<MouseLook> ().YSensitivity = 2;
		}
		else{
			GetComponent<RigidbodyFirstPersonController> ().enabled = false;
			GetComponentInChildren<Camera> ().enabled = false;
			GetComponent<MouseLook> ().XSensitivity = 0;
			GetComponent<MouseLook> ().YSensitivity = 0;
		}

		this.transform.position = new Vector3 (Random.Range (-20, 20), 0, Random.Range (-20, 20));
	}


}