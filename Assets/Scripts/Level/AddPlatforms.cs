using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlatforms : MonoBehaviour
{
    public GameObject platformSpawner;
    private bool platformsSpawned = false;

    private void Start()
    {
        
    }
    public void CheckIfSpawned()
    {
        if(!platformsSpawned)
        {
            GameObject platform = Instantiate(platformSpawner, transform.position, Quaternion.identity);
            platformsSpawned = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("RoomCollider"))
        {

            if (platformsSpawned)
            {
                collision.GetComponent<PlayerInRoom>().SetSpawnedObjects(true);
                Destroy(this.gameObject);
            }
        }
    }
}
