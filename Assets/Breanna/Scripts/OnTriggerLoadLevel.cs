using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerLoadLevel : MonoBehaviour {
    public GameObject guiObject;
    public string levelToLoad;
    
	// Use this for initialization
	void Start () {
        guiObject.SetActive(false);	
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //&& other.gameObject.tag == "player2"
            guiObject.SetActive(true);
            if(guiObject.activeInHierarchy == true && Input.GetButtonDown("Fire2"))
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }

    private void OnTriggerExit()
    {
        guiObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
