using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Jeep : NetworkBehaviour {

    private float inc = 0.1f;
    Vector3 Origin;
    private float seconds = 0f;

    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponent<Jeep>().enabled = true;
            JeepCam.target = this.transform;
        }
    }

    // keys to move jeep 
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
            transform.root.position += new Vector3(inc, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.root.position -= new Vector3(inc, 0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
            transform.root.position += new Vector3(0, 0, inc);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.root.position -= new Vector3(0, 0, inc);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.position += (Vector3.up * 40 * Time.deltaTime);
        }

        seconds += Time.deltaTime;

    }

    // game ends when jeep is pushed out of screen or falls into water
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }


        // resets jeep position when it moves from origin
        if (collision.gameObject.tag == "Stop")
        {
            Destroy(gameObject);
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<Renderer>().materials[0].color = Color.red;
    }
}
