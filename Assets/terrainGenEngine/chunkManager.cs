using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chunkManager : MonoBehaviour
{
    public static int amtChunks = 1; // default 1

    private Camera cam;
    private Vector3 camPos;

    private Vector3 chunkPos;
    //private Vector3[] chunkList;

    void Start()
    {
        //cam = Camera.main;

        //chunkPos = generationEngine.chunkPos;
        //chunkList[amtChunks] = chunkPos;
    }

    void Update()
    {
        //camPos = cam.transform.position;
    }
}
