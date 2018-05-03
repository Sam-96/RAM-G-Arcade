using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColor : MonoBehaviour {
    public Color ObjectColor;
    public Color currentColor;
    public Material materialColored;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //creates a new material and allows color toggling
        materialColored = new Material(Shader.Find("Diffuse"))
        {
            color = currentColor = ObjectColor
        };
        this.GetComponent<Renderer>().material = materialColored;
    }
}
