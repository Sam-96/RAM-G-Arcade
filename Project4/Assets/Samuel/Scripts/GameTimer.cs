using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public Text gameTimerText;
    float gameTimer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameTimer += Time.deltaTime;

        //Creates game timer during gameplay displayed with hours, mins, and secs
        int secs = (int)(gameTimer % 60);
        int mins = (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer / 3600) % 24;

        string timerStr = string.Format("{0:0}:{1:00}:{2:00}", hours, mins, secs);

        gameTimerText.text = timerStr;
    }
}
