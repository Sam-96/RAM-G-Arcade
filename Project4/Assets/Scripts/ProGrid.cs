using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProGrid : MonoBehaviour {

    Mesh mesh;
    Vector3[] verts;
    int[] triangles;

    //For the grid
    public Vector3 gridOffset;
    public int gridSize;
    public float cellSize = 1;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Use this for initialization
    void Start () {
        MakeDiscreteProGrid();
        UpdateMesh();
     


    }
	
	// Update is called once per frame
	void UpdateMesh () {
        mesh.Clear();
        mesh.vertices = verts;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    void MakeDiscreteProGrid()
    {
        //Sets array size
        verts = new Vector3[gridSize * gridSize * 4];
        triangles = new int[gridSize * gridSize * 6];

        //set tracker ints
        int v = 0;
        int t = 0;

        //Sets vertex offset
        float vertOffset = cellSize * 0.5f;

        
        for(int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 cellOffset = new Vector3(x * cellSize, 0, y * cellSize);

                //Populate the verts and triangle arrays
                verts[v] = new Vector3(-vertOffset, 0, -vertOffset) + cellOffset + gridOffset;
                verts[v+1] = new Vector3(-vertOffset, 0, vertOffset) + cellOffset + gridOffset;
                verts[v+2] = new Vector3(vertOffset, 0, -vertOffset) + cellOffset + gridOffset;
                verts[v+3] = new Vector3(vertOffset, 0, vertOffset) + cellOffset + gridOffset;

                triangles[t] = v;
                triangles[t+1] = triangles[t+4] = v+1;
                triangles[t+2] = triangles[t+3] = v+2;
                triangles[t+5] = v+3;

                v += 4;
                t += 6;
            }
        }
    }
}
