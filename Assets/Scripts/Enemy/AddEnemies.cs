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
        if (overlapRoom != null && !overlapRoom.GetComponent<PlayerInRoom>().GetSpawnedPlatforms())
        {
            Instantiate(enemySpawner, transform.position, Quaternion.identity);
            enemiesSpawned = true;
        }
    }
    private void Update()
    {
        if (enemiesSpawned && overlapRoom != null)
        {
            overlapRoom.GetComponent<PlayerInRoom>().SetSpawnedPlatforms(true);
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
