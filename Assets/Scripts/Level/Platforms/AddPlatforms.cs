using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is attached to the nodes in order to instantiate 
//platform template game objects within the level
public class AddPlatforms : MonoBehaviour
{
    public GameObject platformSpawner;
    private bool platformsSpawned = false;
    private GameObject overlapRoom;

    //Is called when a node is created
    public void CheckIfSpawned()
    {
        //checks if the overlapping room already has platforms spawned within it
        if (overlapRoom != null && !overlapRoom.GetComponent<PlayerInRoom>().GetSpawnedPlatforms())
        {
            GameObject platformSpawnerInst = Instantiate(platformSpawner, transform.position, Quaternion.identity);
            platformSpawnerInst.transform.parent = overlapRoom.transform;
            platformsSpawned = true;
        }
    }
    private void Update()
    {
        //Sets the rooms enemy spawned state
        if (platformsSpawned && overlapRoom != null)
        {
            overlapRoom.GetComponent<PlayerInRoom>().SetSpawnedPlatforms(true);
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
