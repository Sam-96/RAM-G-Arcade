using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    public GameObject[] waterBody = new GameObject[7];
    const float Length = 100f; 
    const float Speed = 5f; 

    void Update()
    {
        // moves each water piece to the back of the rotation when they reach Length
        foreach (GameObject waves in waterBody)
        {
            Vector3 newPosition = waves.transform.position;
            newPosition.z -= Speed * Time.deltaTime;
            if (newPosition.z < -Length)
            {
                newPosition.z += Length;
            }
            waves.transform.position = newPosition;
        }
    }
}
