using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public List<Items> items;
    private List<Transform> itemSpawnPoints = new();
    private int defaultTotalWeight = 0;
    private int totalWeight = 0;
    private int sumOfIndexes = 0;

    private void Start()
    {

        foreach (Transform child in transform)
        {
            if(child.CompareTag("ItemSpawnPoint"))
            {
                itemSpawnPoints.Add(child);
            }
        }
        foreach (Items itemType in items)
        {
            defaultTotalWeight += itemType.weight;
            totalWeight = defaultTotalWeight;
        }
        totalWeight += 50;
        foreach (Transform itemSP in itemSpawnPoints)
        {
            int randomNum = Random.Range(0, totalWeight);
            bool itemSpawned = false;
            if(!itemSpawned)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (randomNum <= (items[i].weight + sumOfIndexes))
                    {
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
