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
        if (overlapRoom != null && !overlapRoom.GetComponent<PlayerInRoom>().GetSpawnedPlatforms())
        {
            GameObject platformSpawnerInst = Instantiate(platformSpawner, transform.position, Quaternion.identity);
            platformSpawnerInst.transform.parent = overlapRoom.transform;
            platformsSpawned = true;
        }
    }
    private void Update()
    {
        if (platformsSpawned && overlapRoom != null)
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
