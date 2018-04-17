using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyFlight : MonoBehaviour {

	public GameObject player;
	public GameObject boidPrefab;
	public GameObject goalPrefab;
	public static int roamSize = 20;
	public static int targetRange = 8;
	public bool followPlayer = true;

	static int numBoidz = 10;
	public static GameObject[] allBoidz = new GameObject[numBoidz];
	public static Vector3 goalPos = Vector3.zero;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numBoidz; i++) {
			Vector3 pos = new Vector3(	Random.Range (-targetRange, targetRange),
				Random.Range (0,1),
				Random.Range (-targetRange, targetRange));
			allBoidz [i] = (GameObject)Instantiate (boidPrefab, pos, Quaternion.identity);

		}
	}

	// Update is called once per frame
	void Update () {

		if (followPlayer == true) {
			goalPos = player.transform.position;

			//var playerObject = GameObject.Find("Player");
			//goalPos = playerObject.transform.position;
		}

	}
}