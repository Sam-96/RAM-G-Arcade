using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedRndmSpawn: MonoBehaviour
{

    //Spawn this object
    public GameObject spawnObject;
    public GameObject spawnObjectTwo;
    public GameObject spawnObjectThree;
    public GameObject spawnObjectFour;

    //Ranges of time when spawning objects
    public float minTime = 0;
    public float maxTime = 0;

    //current time
    private float time;


//The time to spawn the object
private float spawnTime;

    void Start()
    {
        SetRandomTime();
        time = minTime;
    }

    

    void FixedUpdate()
    {

        //Counts up
        time += Time.deltaTime;

        //Check to see if it's the right time to spawn the object
        if (time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }

    }


    //Spawns the object and resets the time
    void SpawnObject()
    {
        //Range of spots to spawn
        float bruh = Random.Range(10, 30);
        float negBruh = Random.Range(-10, -30);
        time = 0f;

        //Spawns objects in random positions around target
        Instantiate(spawnObject, transform.position + (transform.forward * bruh), transform.rotation);
        Instantiate(spawnObjectTwo, transform.position + (transform.forward * bruh), transform.rotation);
        Instantiate(spawnObjectThree, transform.position + (transform.forward * bruh), transform.rotation);
        Instantiate(spawnObjectFour, transform.position + (transform.forward * bruh), transform.rotation);
        Instantiate(spawnObject, transform.position + (transform.forward * negBruh), transform.rotation);
        Instantiate(spawnObjectTwo, transform.position + (transform.forward * negBruh), transform.rotation);
        Instantiate(spawnObjectThree, transform.position + (transform.forward * negBruh), transform.rotation);
        Instantiate(spawnObjectFour, transform.position + (transform.forward * negBruh), transform.rotation);



    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

}