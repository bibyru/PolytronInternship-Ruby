using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    [SerializeField] GameObject house;
    GameObject houseSpawn;

    public void SpawnHouse()
    {
        if (GetComponent<OccupationChecker>().isOccupied == false)
        {
            GetComponent<OccupationChecker>().isOccupied = true;
            houseSpawn = Instantiate(house, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            int score = 2;
            if (name.Contains("Dirt"))
            {
                score = 10;
            }
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>().AddScore(score);
        }
    }
}
