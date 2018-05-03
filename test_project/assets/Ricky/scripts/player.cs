using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour {

	public string levelToLoad;
	public bool alive = true;

	void Update(){

		if(Input.GetKeyDown(KeyCode.M)){ 
			SceneManager.LoadScene (levelToLoad);
		}
	}

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
