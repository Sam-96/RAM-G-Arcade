using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class GenerateTerrain : MonoBehaviour
{

    public float size = 1;
    public int gridSize = 16;
    public int heightScale = 5;
    public float detailScale = 5.0f;

    List<GameObject> myCacti = new List<GameObject>();          //infinite tree

    private MeshFilter filter;

    // Use this for initialization
    void Start()
    {
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenerateMesh();

        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        for (int v = 0; v < vertices.Length; v++)
        {
            vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x) / detailScale,
                            (vertices[v].z + this.transform.position.z) / detailScale) * heightScale;

            if(vertices[v].y > 2.6 && Mathf.PerlinNoise((vertices[v].x + 5)/10, (vertices[v].z+ 5)/10)* 10 > 7.2) //added this whole if
            {
                GameObject newCactus = TreePool.GetCactus();
                if(newCactus != null)
                {
                    Vector3 cactusPos = new Vector3(vertices[v].x + this.transform.position.x,
                                                    vertices[v].y,
                                                    vertices[v].z + this.transform.position.z);
                    newCactus.transform.position = cactusPos;
                    newCactus.SetActive(true);
                    myCacti.Add(newCactus);
                }
            }
            


        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        this.gameObject.AddComponent<MeshCollider>();
    }

    private void OnDestroy()  //added this
    {
        for(int i =  0; i < myCacti.Count; i++)
        {
            if (myCacti[i] != null)
                myCacti[i].SetActive(false);
        }
        myCacti.Clear();

    }


    // Update is called once per frame
    void Update()
    {

    }

    Mesh GenerateMesh()
    {
        Mesh mesh = new Mesh();

        var vertices = new List<Vector3>();
        var normals = new List<Vector3>();
        var uvs = new List<Vector2>();
        for (int x = 0; x < gridSize + 1; ++x)
        {
            for (int y = 0; y < gridSize + 1; ++y)
            {
                vertices.Add(new Vector3(-size * 0.5f + size * (x / ((float)gridSize)), 0, -size * 0.5f + size * (y / ((float)gridSize))));
                normals.Add(Vector3.up);
                uvs.Add(new Vector2(x / (float)gridSize, y / (float)gridSize));
            }
        }

        var triangles = new List<int>();
        var vertCount = gridSize + 1;
        for (int i = 0; i < vertCount * vertCount - vertCount; ++i)
        {
            if ((i + 1) % vertCount == 0)
            {
                continue;
            }
            triangles.AddRange(new List<int>()
            {
                i + 1 + vertCount, i + vertCount, i,
                i, i + 1, i + vertCount + 1
            });
        }

        mesh.SetVertices(vertices);
        mesh.SetNormals(normals);
        mesh.SetUVs(0, uvs);
        mesh.SetTriangles(triangles, 0);

        return mesh;
    }
}
