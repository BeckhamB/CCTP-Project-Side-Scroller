using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script instantiates the platforms dependant on the weighting values of their
//scriptable objects
public class PlatformGenerator : MonoBehaviour
{
    public List<Platforms> platforms;
    private List<Transform> platformSpawnPoints = new();
    private int defaultTotalWeight = 0;
    private int totalWeight = 0;
    private int sumOfIndexes = 0;
    private PlayerInRoom playerInRoom;
    private void Start()
    {
        playerInRoom = GetComponentInParent<PlayerInRoom>();
        //finds the transforms of all spawn points
        foreach (Transform child in transform)
        {
            if(child.CompareTag("PlatformSpawnPoint"))
            {
                platformSpawnPoints.Add(child);
            }
        }
        //Calculates the total weight of all the enemy types
        foreach (Platforms platformType in platforms)
        {
            defaultTotalWeight += platformType.weight;
            totalWeight = defaultTotalWeight;
        }
        //for each spawnpoint in the array
        foreach (Transform platformSP in platformSpawnPoints)
        {
            //a random number is generated between 0 and the total weight
            int randomNum = Random.Range(0, totalWeight);
            bool platformSpawned = false;
            if(!platformSpawned)
            {
                for (int i = 0; i < platforms.Count; i++)
                {
                    //if that value is = to the weight of the platforms + previous weights in the array it is instantiated
                    if (randomNum <= (platforms[i].weight + sumOfIndexes))
                    {
                        GameObject newPlatforms = Instantiate(platforms[i].platform, platformSP.position, Quaternion.identity);
                        newPlatforms.transform.parent = this.transform;
                        platformSpawned = true;
                        sumOfIndexes = 0;
                        break;
                    }
                    else
                    {
                        sumOfIndexes += platforms[i].weight;
                    }
                }
            }
            
            
        }

    }

}
