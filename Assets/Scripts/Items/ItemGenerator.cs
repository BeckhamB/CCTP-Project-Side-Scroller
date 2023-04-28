using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script instantiates the items dependant on the weighting values of their
//scriptable objects
public class ItemGenerator : MonoBehaviour
{
    public List<Items> items;
    private List<Transform> itemSpawnPoints = new();
    private int defaultTotalWeight = 0;
    private int totalWeight = 0;
    private int sumOfIndexes = 0;
    private LevelManager levelManager;
    private PlayerInRoom playerInRoom;
    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
        playerInRoom = GetComponentInParent<PlayerInRoom>();
        //finds the transforms of all spawn points
        foreach (Transform child in transform)
        {
            if(child.CompareTag("ItemSpawnPoint"))
            {
                itemSpawnPoints.Add(child);
            }
        }
        //Calculates the total weight of all the item types
        foreach (Items itemType in items)
        {
            defaultTotalWeight += itemType.weight;
            totalWeight = defaultTotalWeight;
        }
        totalWeight += 50;
        //for each spawnpoint in the array
        foreach (Transform itemSP in itemSpawnPoints)
        {
            //a random number is generated between 0 and the total weight
            int randomNum = Random.Range(0, totalWeight);
            bool itemSpawned = false;
            if(!itemSpawned)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    //if that value is = to the weight of the item + previous weights in the array it is instantiated
                    if (randomNum <= (items[i].weight + sumOfIndexes))
                    {
                        levelManager.SetNumCollectableSpawned(1);
                        playerInRoom.CoinSpawned(1);
                        GameObject newItems = Instantiate(items[i].items, itemSP.position, Quaternion.identity);
                        newItems.transform.parent = this.transform;
                        itemSpawned = true;
                        sumOfIndexes = 0;
                        break;
                    }
                    else
                    {
                        sumOfIndexes += items[i].weight;
                    }
                }
            }
            
            
        }

    }

}
