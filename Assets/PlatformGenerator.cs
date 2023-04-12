using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public List<Platforms> platforms;
    public GameObject[] platformSpawnPoints;
    private int defaultTotalWeight = 0;
    private int totalWeight = 0;
    private int sumOfIndexes = 0;

    private void Start()
    {
        //platforms[0].weight = 10000; 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            platformSpawnPoints = GameObject.FindGameObjectsWithTag("PlatformSpawnPoint");

            foreach (Platforms platformType in platforms)
            {
                defaultTotalWeight += platformType.weight;
                totalWeight = defaultTotalWeight;
            }
            foreach (GameObject platformSP in platformSpawnPoints)
            {
                int randomNum = Random.Range(0, totalWeight);
                for (int i = 0; i < platforms.Count; i++)
                {
                    Debug.Log(sumOfIndexes);
                    if (randomNum <= (platforms[i].weight + sumOfIndexes))
                    {
                        Instantiate(platforms[i].platform, platformSP.gameObject.transform.position, Quaternion.identity);
                    }
                    else
                    {
                        sumOfIndexes += platforms[i].weight;
                    }
                }
                sumOfIndexes = 0;
            }
        }
    }
}
