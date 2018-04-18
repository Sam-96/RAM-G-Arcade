using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public bool alive = true;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "eyes")
		{
			other.transform.parent.GetComponent<monster>().checkSight();
		}
		else if(other.CompareTag("lostPage"))
		{
			Destroy(other.gameObject);
			gameplayCanvas.instance.findPage();
		}
	}

}
