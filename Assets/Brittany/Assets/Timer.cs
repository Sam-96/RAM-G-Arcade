using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

    private float seconds = 0f;
    public Text Score;
	
	void Update () {
        seconds += Time.deltaTime;

        Score.text = "Time: " + seconds.ToString() + " seconds";
	}
}
