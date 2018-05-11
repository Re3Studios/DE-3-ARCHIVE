using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generationEngine : MonoBehaviour
{
    private GameObject currentGameObject;
    public GameObject[] blockListAscendingOrder;

    public static int chunkSize = 16; // default 16
    public int seed;
    private int amtChunks;

    public static int[] blockPosX;
    public static int[] blockPosY;
    public static int[] blockPosZ;

    public int seaLevel;

    public int freq;
    public int amp;

    public static Vector3 chunkPos;

    void Start()
    {
        // Terrain Configuration
        seed = Random.Range(0, 99999);
        amtChunks = chunkManager.amtChunks;

        blockPosX = new int[chunkSize * chunkSize];
        blockPosY = new int[chunkSize * chunkSize];
        blockPosZ = new int[chunkSize * chunkSize];

        terrainGenerator();
    }

    void terrainGenerator()
    {
        // Chunk Grouping
        chunkPos = this.transform.position;
        GameObject chunk = new GameObject("chunk");
        chunk.transform.parent = gameObject.transform;

        int u = 0;

        for (int c = 0; c < amtChunks; c++)
        {
            for (int x = 0; x < chunkSize; x++)
            {
                for (int z = 0; z < chunkSize; z++)
                {
                    // Creates a "realisitic" terrain using perlin noise
                    float seaLevel = Mathf.PerlinNoise((seed + chunkPos.x + x) / freq, (chunkPos.z + z) / freq) * amp;
                    seaLevel = Mathf.Floor(seaLevel);

                    // Grabs the array of blocks and passes those blocks to be cloned on a certain level.
                    if (seaLevel > amp / 3) currentGameObject = blockListAscendingOrder[0];
                    else currentGameObject = blockListAscendingOrder[1];

                    blockPosX[u] = x;
                    blockPosY[u] = Mathf.FloorToInt(seaLevel);
                    blockPosZ[u] = z;

                    // Setting Blocks Location
                    var cloneBlock = Instantiate(currentGameObject, new Vector3(x, seaLevel, z), Quaternion.identity);
                    cloneBlock.transform.parent = chunk.transform;

                    cloneBlock.name = "Block Pos: X:" + blockPosX[u] + " Y:" + blockPosY[u] + " Z:" + blockPosZ[u];
                    u = u + 1;

                    //for (int y = 0; y < seaLevel; y++)
                    //{
                        //var lowerBlocks = Instantiate(currentGameObject, new Vector3(x, y, z), Quaternion.identity);
                        //lowerBlocks.transform.parent = chunk.transform;

                        //blockPosX[u] = x;
                        //blockPosY[u] = Mathf.FloorToInt(seaLevel);
                        //blockPosZ[u] = z;

                        //u = u + 1;
                    //}
                }
            }
        }
    }
}