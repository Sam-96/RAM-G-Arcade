using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Vehicles.Aeroplane;

public class SetupLocalPlayer : NetworkBehaviour {

    [SyncVar]
    public string pname = "player";

    [SyncVar]
    public Color playerColor = Color.white;

    void OnGUI()
    {
        if(isLocalPlayer)
        {
            pname = GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), pname);
            if(GUI.Button(new Rect(130,Screen.height - 40,80,30),"Change"))
            {
                CmdChangeName(pname);
            }
        }
    }

    [Command]
    public void CmdChangeName(string newName)
    {
        pname = newName;
        this.GetComponentInChildren<TextMesh>().text = pname;
    }

    // Use this for initialization
    void Start () {
		if(isLocalPlayer)
        {
            GetComponent<AeroplaneController>().enabled = true;
            CameraFollow.target = this.transform;

            /*  Renderer[] rends = GetComponentInChildren<Renderer>();
              foreach (Renderer r in rends)
                  r.material.color = playerColor;
            */
        }

        this.transform.position = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
	}
	
	// Update is called once per frame
	void Update () {
       // this.GetComponentInChildren<TextMesh>().text = pname;
	}
}
