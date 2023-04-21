using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public List<Enemies> enemies;
    private List<Transform> enemySpawnPoints = new();
    private int defaultTotalWeight = 0;
    private int totalWeight = 0;
    private int sumOfIndexes = 0;
    private PlayerInRoom playerInRoom;
    private void Start()
    {
        playerInRoom = GetComponentInParent<PlayerInRoom>();
        foreach (Transform child in transform)
        {
            if(child.CompareTag("EnemySpawnPoint"))
            {
                enemySpawnPoints.Add(child);
            }
        }
        foreach (Enemies enemyType in enemies)
        {
            defaultTotalWeight += enemyType.weight;
            totalWeight = defaultTotalWeight;
        }
        totalWeight += 50;
        foreach (Transform enemySP in enemySpawnPoints)
        {
            int randomNum = Random.Range(0, totalWeight);
            bool enemySpawned = false;
            if(!enemySpawned)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (randomNum <= (enemies[i].weight + sumOfIndexes))
                    {
                        GameObject newEnemies = Instantiate(enemies[i].enemies, enemySP.position, Quaternion.identity);
                        newEnemies.transform.parent = this.transform;
                        enemySpawned = true;
                        sumOfIndexes = 0;
                        break;
                    }
                    else
                    {
                        sumOfIndexes += enemies[i].weight;
                    }
                }
            }
            
            
        }

    }

}
