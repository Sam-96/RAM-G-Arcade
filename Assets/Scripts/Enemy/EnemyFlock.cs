using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

	public float movementSpeed = 0.8f;
	float turnSpeed = 5.0f;
	Vector3 averageHeading;
	Vector3 averagePosition;
	float neighborDistance = 10.0f;
	bool turning = false;

	// Use this for initialization
	void Start () {
		movementSpeed = Random.Range (0.5f, 0.8f);
	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, Vector3.zero) >= LazyFlight.roamSize) {
			turning = true;
		} 
		else {
			turning = false;
		}

		if (turning == true) {
			Vector3 direction = Vector3.zero - transform.position;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), turnSpeed * Time.deltaTime);

			movementSpeed = Random.Range (0.5f, 0.8f);
		} 
		else {
			if (Random.Range (0, 5) < 1)
				ApplyRules ();
		}
		transform.Translate(0,0, Time.deltaTime *movementSpeed);
	}

	void ApplyRules()
	{
		GameObject[] gos;
		gos = LazyFlight.allBoidz;

		Vector3 vcenter = Vector3.zero;
		Vector3 vavoid = Vector3.zero;
		float gSpeed = 0.1f;

		Vector3 goalPos = LazyFlight.goalPos;

		float dist;
		int groupSize = 0;

		foreach (GameObject go in gos) {
			if (go != this.gameObject) {
				dist = Vector3.Distance (go.transform.position, this.transform.position);
				if (dist <= neighborDistance) {
					vcenter += go.transform.position;
					groupSize++;

					if (dist < 1.0f)
					{
						vavoid = vavoid + (this.transform.position - go.transform.position);
					}

					Flock anotherFlock = go.GetComponent<Flock>();
					gSpeed = gSpeed + anotherFlock.movementSpeed;
				}
			}
		}

		if(groupSize > 0)
		{
			vcenter = vcenter/groupSize + (goalPos - this.transform.position);
			movementSpeed = gSpeed/groupSize;

			Vector3 direction = (vcenter + vavoid) - transform.position;
			if(direction != Vector3.zero)
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
		}
	}
}
