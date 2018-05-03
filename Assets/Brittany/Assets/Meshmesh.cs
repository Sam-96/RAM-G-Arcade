// Unity3D Mesh Simple Creation

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Meshmesh : MonoBehaviour
{
    public Vector3[] newVertices;
    //public Vector2[] newUV;
    //public int[] newTriangles;
    public int xSize, ySize;
    private Mesh mesh;

    private void Awake()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.05f);

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid";

        newVertices = new Vector3[(xSize + 1) * (ySize + 1)];
        for(int i = 0, y = 0; y <= ySize; y++)
        {
            for(int x = 0; x <= xSize; x++, i++)
            {
                newVertices[i] = new Vector3(x, y);
                yield return wait;
            }
        }
        mesh.vertices = newVertices;

        int[] triangles = new int[6];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 1;
        triangles[4] = xSize + 1;
        triangles[5] = xSize + 1;
        mesh.triangles = triangles;

    }

    private void OnDrawGizmos()
    {
        if (newVertices == null)
        {
            return;
        }
        Gizmos.color = Color.cyan;
        for (int i = 0; i < newVertices.Length; i++)
        {
            Gizmos.DrawSphere(newVertices[i], 0.1f);
        }
    }

    void Start()
    {
        /*Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;*/

    }
}