using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBlock : MonoBehaviour {

    public Material cubeMaterial;

    enum cubeside {BOTTOM, TOP, LEFT, RIGHT, FRONT, BACK};

    void createQuad(cubeside side)
    {
        Mesh mesh = new Mesh();
        mesh.name = "cubeMesh" + side.ToString();

        Vector3[] vertices = new Vector3[4];
        Vector3[] normals = new Vector3[4];
        Vector2[] uvs = new Vector2[4];
        int[] triangles = new int[6];

        Vector2 uv00 = new Vector2( 0f, 0f );
        Vector2 uv10 = new Vector2( 1f, 0f );
        Vector2 uv01 = new Vector2( 0f, 1f );
        Vector2 uv11 = new Vector2( 1f, 1f );

        Vector3 p0 = new Vector3( -0.5f, -0.5f,  0.5f );
        Vector3 p1 = new Vector3(  0.5f, -0.5f,  0.5f );
        Vector3 p2 = new Vector3(  0.5f, -0.5f, -0.5f );
        Vector3 p3 = new Vector3( -0.5f, -0.5f, -0.5f );
        Vector3 p4 = new Vector3( -0.5f,  0.5f,  0.5f );
        Vector3 p5 = new Vector3(  0.5f,  0.5f,  0.5f );
        Vector3 p6 = new Vector3(  0.5f,  0.5f, -0.5f );
        Vector3 p7 = new Vector3( -0.5f,  0.5f, -0.5f );

        switch(side)
        {
            case cubeside.BOTTOM:
                vertices = new Vector3[] {p0, p1, p2, p3};
                normals = new Vector3[] { Vector3.down, Vector3.down,
                                          Vector3.down, Vector3.down };
                uvs = new Vector2[] {uv11, uv01, uv00, uv10};
                triangles = new int[] { 3, 1, 0, 3, 2, 1};
            break;
            case cubeside.TOP:
                vertices = new Vector3[] { p7, p6, p5, p4 };
                normals = new Vector3[] { Vector3.up, Vector3.up,
                                          Vector3.up, Vector3.up };
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangles = new int[] { 3, 1, 0, 3, 2, 1 };
            break;
            case cubeside.LEFT:
                vertices = new Vector3[] { p7, p4, p0, p3 };
                normals = new Vector3[] { Vector3.left, Vector3.left,
                                          Vector3.left, Vector3.left };
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangles = new int[] { 3, 1, 0, 3, 2, 1 };
            break;
            case cubeside.RIGHT:
                vertices = new Vector3[] { p5, p6, p2, p1 };
                normals = new Vector3[] { Vector3.right, Vector3.right,
                                          Vector3.right, Vector3.right };
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangles = new int[] { 3, 1, 0, 3, 2, 1 };
            break;
            case cubeside.FRONT:
                vertices = new Vector3[] { p4, p5, p1, p0 };
                normals = new Vector3[] { Vector3.forward, Vector3.forward,
                                          Vector3.forward, Vector3.forward };
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangles = new int[] { 3, 1, 0, 3, 2, 1 };
            break;
            case cubeside.BACK:
                vertices = new Vector3[] { p6, p7, p3, p2 };
                normals = new Vector3[] { Vector3.back, Vector3.back,
                                          Vector3.back, Vector3.back };
                uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                triangles = new int[] { 3, 1, 0, 3, 2, 1 };
            break;
        }

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();

        GameObject quad = new GameObject("Quad");
        quad.transform.parent = this.gameObject.transform;
        MeshFilter meshFilter = (MeshFilter)quad.AddComponent(typeof(MeshFilter));
        meshFilter.mesh = mesh;
        MeshRenderer renderer = quad.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        renderer.material = cubeMaterial;
    }

    //void onCollision()
    //{
    //    MeshCollider col = (MeshFilter)quad.AddComponent(typeof(MeshCollider)) as MeshCollider;

    //    if (col.collider.name == this.gameObject)
    //    {
    //        Delete(quad);
    //    }
    //}

    void combineQuads()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            i++;
        }

        MeshFilter mf = (MeshFilter)this.gameObject.AddComponent(typeof(MeshFilter));
        mf.mesh = new Mesh();

        mf.mesh.CombineMeshes(combine);

        MeshRenderer renderer = this.gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        renderer.material = cubeMaterial;

        foreach (Transform quad in this.transform)
        {
            Destroy(quad.gameObject);
        }
    }

    void createCube()
    {
        createQuad(cubeside.FRONT);
        createQuad(cubeside.BACK);
        createQuad(cubeside.TOP);
        createQuad(cubeside.BOTTOM);
        createQuad(cubeside.LEFT);
        createQuad(cubeside.RIGHT);
    }

    void Start()
    {
        createCube();
        //onCollision();
        combineQuads();
    }
}
