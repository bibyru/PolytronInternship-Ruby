using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] GameObject tree;
    GameObject[] dirts;

    float treeSpawnRate = 1f;
    float treeSpawnTimer = 0;



    private void Start()
    {
        ResetTreeSpawnTimer();
    }

    void Update()
    {
        if (treeSpawnTimer > 0)
        {
            treeSpawnTimer -= Time.deltaTime;
        }
        else
        {
            ResetTreeSpawnTimer();
            GrowTree();
        }
    }



    void ResetTreeSpawnTimer()
    {
        treeSpawnTimer = treeSpawnRate;
    }



    void GrowTree()
    {
        if (dirts == null)
        {
            dirts = GameObject.FindGameObjectsWithTag("Dirt");
        }

        int randomIndex = Random.Range(0, dirts.Length);
        GameObject dirt = dirts[randomIndex];



        int oldIndex = randomIndex;
        bool noDirtLeft = false;
        while (dirt.GetComponent<OccupationChecker>().isOccupied == true)
        {
            randomIndex++;
            
            if (randomIndex == oldIndex)
            {
                noDirtLeft = true;
                break;
            }

            if (randomIndex >= dirts.Length)
            {
                randomIndex = 0;
            }

            dirt = dirts[randomIndex];
        }



        if (noDirtLeft == true)
        {
            GetComponent<TreeSpawner>().enabled = false;
        }
        else
        {
            dirt.GetComponent<OccupationChecker>().isOccupied = true;

            Vector3 spawnPosition = dirt.transform.position;
            GameObject treeSpawn = Instantiate(tree, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z), Quaternion.identity);
            treeSpawn.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
