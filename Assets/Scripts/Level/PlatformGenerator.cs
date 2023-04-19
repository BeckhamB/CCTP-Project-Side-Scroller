using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public List<Platforms> platforms;
    private List<Transform> platformSpawnPoints = new();
    private int defaultTotalWeight = 0;
    private int totalWeight = 0;
    private int sumOfIndexes = 0;

    private void Start()
    {

        foreach (Transform child in transform)
        {
            if(child.CompareTag("PlatformSpawnPoint"))
            {
                platformSpawnPoints.Add(child);
            }
        }
        foreach (Platforms platformType in platforms)
        {
            defaultTotalWeight += platformType.weight;
            totalWeight = defaultTotalWeight;
        }
        foreach (Transform platformSP in platformSpawnPoints)
        {
            int randomNum = Random.Range(0, totalWeight);
            for (int i = 0; i < platforms.Count; i++)
            {
                if (randomNum <= (platforms[i].weight + sumOfIndexes))
                {
                    GameObject newPlatforms = Instantiate(platforms[i].platform, platformSP.position, Quaternion.identity);
                    newPlatforms.transform.parent = this.transform;
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
