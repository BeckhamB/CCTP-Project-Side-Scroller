using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script instantiates the enemies dependant on the weighting values of their
//scriptable objects
public class EnemyGenerator : MonoBehaviour
{
    public List<Enemies> enemies;
    private List<Transform> enemySpawnPoints = new();
    private int defaultTotalWeight = 0;
    private int totalWeight = 0;
    private int sumOfIndexes = 0;
    private PlayerInRoom playerInRoom;
    private LevelManager levelManager;
    private void Start()
    {
        playerInRoom = GetComponentInParent<PlayerInRoom>();
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();

        //finds the transforms of all spawn points
        foreach (Transform child in transform)
        {
            if(child.CompareTag("EnemySpawnPoint"))
            {
                enemySpawnPoints.Add(child);
            }
        }
        //Calculates the total weight of all the enemy types
        foreach (Enemies enemyType in enemies)
        {
            defaultTotalWeight += enemyType.weight;
            totalWeight = defaultTotalWeight;
        }
        //this adds a chance of no enemy spawning
        totalWeight += 50;
        //for each spawnpoint in the array
        foreach (Transform enemySP in enemySpawnPoints)
        {
            //a random number is generated between 0 and the total weight
            int randomNum = Random.Range(0, totalWeight);
            bool enemySpawned = false;
            if(!enemySpawned)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    //if that value is = to the weight of the enemy + previous weights in the array it is instantiated
                    if (randomNum <= (enemies[i].weight + sumOfIndexes))
                    {
                        levelManager.SetNumEnemySpawned(1);
                        playerInRoom.EnemiesSpawned(1);
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
