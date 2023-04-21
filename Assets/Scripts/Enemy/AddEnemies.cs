using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemies : MonoBehaviour
{
    public GameObject enemySpawner;
    private bool enemiesSpawned = false;
    private GameObject overlapRoom;

    public void CheckIfSpawned()
    {
        if (overlapRoom != null && !overlapRoom.GetComponent<PlayerInRoom>().GetSpawnedEnemies())
        {
            GameObject enemySpawnerInst = Instantiate(enemySpawner, transform.position, Quaternion.identity);
            enemySpawnerInst.transform.parent = overlapRoom.transform;
            enemiesSpawned = true;
        }
    }
    private void Update()
    {
        if (enemiesSpawned && overlapRoom != null)
        {
            overlapRoom.GetComponent<PlayerInRoom>().SetSpawnedEnemies(true);
            //Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInRoom>() != null)
        {
            overlapRoom = collision.gameObject;

        }


    }
}
