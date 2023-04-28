using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is attached to the nodes in order to instantiate 
//enemy template game objects within the level
public class AddEnemies : MonoBehaviour
{
    public GameObject enemySpawner;
    private bool enemiesSpawned = false;
    private GameObject overlapRoom;

    //Is called when a node is created
    public void CheckIfSpawned()
    {
        //checks if the overlapping room already has enemies spawned within it
        if (overlapRoom != null && !overlapRoom.GetComponent<PlayerInRoom>().GetSpawnedEnemies())
        {
            GameObject enemySpawnerInst = Instantiate(enemySpawner, transform.position, Quaternion.identity);
            enemySpawnerInst.transform.parent = overlapRoom.transform;
            enemiesSpawned = true;
        }
    }
    private void Update()
    {
        //Sets the rooms enemy spawned state
        if (enemiesSpawned && overlapRoom != null)
        {
            overlapRoom.GetComponent<PlayerInRoom>().SetSpawnedEnemies(true);
            //Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detects the overlapping room with this node through box collider triggers
        if (collision.GetComponent<PlayerInRoom>() != null)
        {
            overlapRoom = collision.gameObject;

        }


    }
}
