using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePool : MonoBehaviour {


    int numCactus = 1000;
    public GameObject cactusPrefab;
    static GameObject[] cactuses;


    // Use this for initialization
    void Start()
    {
        cactuses = new GameObject[numCactus];
        for (int i = 0; i < numCactus; i++)
        {
            cactuses[i] = (GameObject)Instantiate(cactusPrefab, Vector3.zero, Quaternion.identity);
            cactuses[i].SetActive(false);
        }

    }
    static public GameObject GetCactus()
    {
        for (int i = 0; i < 1000; i++)
        {
            if (!cactuses[i].activeSelf)
            {
                return cactuses[i];
            }
        }
        return null;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
