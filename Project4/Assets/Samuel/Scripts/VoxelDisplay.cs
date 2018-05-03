using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class VoxelDisplay : MonoBehaviour {

    Mesh mesh;
    List<Vector3> verts;
    List<int> triangles;

    public float scale = 1f;
    public float halfscale;
    public Color ObjectColor;
    public Color currentColor;
    public Material materialColored;
    public int posX, posY, posZ;



    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        halfscale = scale * 0.5f;
    }

    // Use this for initialization
    void Start()
    {
        MakeVoxMesh(new VoxelInfo());
        UpdateMesh();
    }

    void MakeVoxMesh(VoxelInfo data) {
        verts = new List<Vector3>();
        triangles = new List<int>();


        for (int i = 0; i < data.Depth; i++)
        {
            for (int j = 0; j < data.Width; j++)
            {
                if(data.GetCell(i,j) == 0)
                {
                    continue;
                }
                MakeDaCube(halfscale, new Vector3((float)i * scale, 0, (float)j * scale));
            }
        }
    }

    // Update is called once per frame
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = verts.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();

        //creates a new material and allows color toggling
        materialColored = new Material(Shader.Find("Diffuse"))
        {
            color = currentColor = ObjectColor
        };
        this.GetComponent<Renderer>().material = materialColored;
    }

    void MakeDaCube(float cScale, Vector3 cPos)
    { 
        for (int i = 0; i < 6; i++)
        {
            MakeDaFace(i, cScale, cPos);
        }
    }

    void MakeDaFace(int dir, float fScale, Vector3 fPos)
    {
        verts.AddRange(CubeMeshData.faceVerts(dir, fScale, fPos));
        int vertCount = verts.Count;

        triangles.Add(verts.Count - 4);
        triangles.Add(verts.Count - 4 + 1);
        triangles.Add(verts.Count - 4 + 2);
        triangles.Add(verts.Count - 4);
        triangles.Add(verts.Count - 4 + 2);
        triangles.Add(verts.Count - 4 + 3);

    }
}


