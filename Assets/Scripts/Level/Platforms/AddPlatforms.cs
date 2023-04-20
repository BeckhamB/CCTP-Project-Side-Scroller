using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlatforms : MonoBehaviour
{
    public GameObject platformSpawner;
    private bool platformsSpawned = false;
    private GameObject overlapRoom;

    public void CheckIfSpawned()
    {
        if (overlapRoom != null && !overlapRoom.GetComponent<PlayerInRoom>().GetSpawnedObjects())
        {
            Instantiate(platformSpawner, transform.position, Quaternion.identity);
            platformsSpawned = true;
        }
    }
    private void Update()
    {
        if (platformsSpawned && overlapRoom != null)
        {
            overlapRoom.GetComponent<PlayerInRoom>().SetSpawnedObjects(true);
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
