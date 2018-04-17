using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    public void PlayGame(string newScene)
    {
        //add script
        SceneManager.LoadScene(newScene);

    }
}
