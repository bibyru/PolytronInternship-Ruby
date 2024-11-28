using System;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> tileTypes;
    public List<GameObject> tileSpawns = new List<GameObject>();

    int tileCount = 8;
    float spawnPositionX = 0;
    float spawnPositionZ = 0;
    float positionTranslation = 1f;

    private void Start()
    {
        FormTiles();
        SpawnTiles();
    }




    void FormTiles() // This function makes a list of all tiles that will be spawned.
    {

        // The For statement below makes an array of numbers for each type of
        // tiles to ensure all tile types are spawned.

        int[] tileTypeCounts = new int[tileTypes.Count];
        int sumTilesFilled = 0;
        for (int i = 0; i < tileTypes.Count; i++)
        {
            if (i == tileTypes.Count - 1)
            {
                tileTypeCounts[i] = (tileCount * tileCount) - sumTilesFilled;
                break;
            }

            int tileTypeCount = UnityEngine.Random.Range(8, 10);
            tileTypeCounts[i] = tileTypeCount;
            sumTilesFilled += tileTypeCount;
        }



        // The For statement below randomly fills an array of
        // tiles that will be spawned in-game.

        for (int i = 0; i < tileCount * tileCount; i++)
        {
            int typeIndex = UnityEngine.Random.Range(0, tileTypes.Count);
            while (tileTypeCounts[typeIndex] <= 0)
            {
                typeIndex++;
                if (typeIndex >= tileTypes.Count)
                {
                    typeIndex = 0;
                }
            }

            tileSpawns.Add(tileTypes[typeIndex]);
            tileTypeCounts[typeIndex]--;
        }
    }



    void SpawnTiles() // This function spawns tiles in-game.
    {
        for (int i = 1; i <= tileSpawns.Count; i++)
        {
            Vector3 spawnPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);
            Instantiate(tileSpawns[i-1], spawnPosition, Quaternion.identity);

            spawnPositionX += positionTranslation;
            if (i % tileCount == 0)
            {
                spawnPositionX = 0;
                spawnPositionZ += positionTranslation;
            }
        }
    }
}
