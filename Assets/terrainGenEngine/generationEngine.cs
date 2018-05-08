using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generationEngine : MonoBehaviour
{
    private GameObject currentGameObject;
    public GameObject[] blockListAscendingOrder;

    public int chunkSize = 16; // default 16
    public int seed;
    private int amtChunks;

    public int seaLevel;

    public int freq;
    public int amp;

    public static Vector3 chunkPos;

    void Start()
    {
        // Terrain Configuration
        seed = Random.Range(1, 99999);
        amtChunks = chunkManager.amtChunks;

        terrainGenerator();
    }

    void terrainGenerator()
    {
        // Chunk Grouping
        chunkPos = this.transform.position;
        GameObject chunk = new GameObject("chunk");
        chunk.transform.parent = gameObject.transform;

        for (int c = 0; c < amtChunks; c++)
        {
            for (int x = 0; x < chunkSize; x++)
            {
                for (int z = 0; z < chunkSize; z++)
                {
                    // Creates a "realisitic" terrain using perlin noise
                    float y = Mathf.PerlinNoise((seed + chunkPos.x + x) / freq, (chunkPos.z + z) / freq) * amp;
                    y = Mathf.Floor(y);

                    // Grabs the array of blocks and passes those blocks to be cloned on a certain level.
                    if (y > amp / 3) currentGameObject = blockListAscendingOrder[0];
                    else currentGameObject = blockListAscendingOrder[1];

                    // Setting Blocks Location
                    var cloneBlock = Instantiate(currentGameObject, new Vector3(x, y, z), Quaternion.identity);
                    cloneBlock.transform.parent = chunk.transform;
                }
            }
        }
    }
}