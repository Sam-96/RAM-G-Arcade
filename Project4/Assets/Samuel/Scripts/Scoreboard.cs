using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Scoreboard : MonoBehaviour {

    public int _score = 0;
    public Text score;

    public void Start()
    {
        SetScoreText();
    }

    public void Update()
    {
        //Resets the scene
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("MainMesh");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if collision is a Mesh Object
        if (collision.gameObject.tag == "Meshy")
        {
            _score++;
            SetScoreText();

        }
    }

    void SetScoreText()
    {
        score.text = "Hits: " + _score.ToString();
        if(_score >= 300)
        {
            SceneManager.LoadScene("End Scene");
        }

    }
}
