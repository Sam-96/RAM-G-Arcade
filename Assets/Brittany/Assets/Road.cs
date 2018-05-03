using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Road : MonoBehaviour {

    public GameObject[] Roads = new GameObject[3];
    const float Length = 200f; 
    public static float Speed = 7f;

    void Update()
    {
        // moves each road piece to the back of the rotation when they reach Length
        foreach (GameObject road in Roads)
        {
            Vector3 newPosition = road.transform.position;
            newPosition.z -= Speed * Time.deltaTime;
            if (newPosition.z < -Length / 2)
            {
                newPosition.z += Length;
            }
            road.transform.position = newPosition;
        }

    }
}
