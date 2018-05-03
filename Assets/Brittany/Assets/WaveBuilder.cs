using System.Collections;
using UnityEngine;

public class WaveBuilder : MonoBehaviour
{
    float waveSpeed = 3f;
    float waveScale = 1f;
    private Vector3[] height;
	
	void Update ()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        if (height == null)
            height = mesh.vertices;

        Vector3[] vertices = new Vector3[height.Length];

        // transforms mesh verticies on a sin interval
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = height[i];
            vertex.y += (Mathf.Sin(Time.time * waveSpeed + height[i].x + height[i].y + height[i].z) * waveScale);
            vertices[i] = vertex;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
	}
}
