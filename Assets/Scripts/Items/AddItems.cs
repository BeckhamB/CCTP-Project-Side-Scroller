using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is attached to the nodes in order to instantiate 
//item template game objects within the level
public class AddItems : MonoBehaviour
{
    public GameObject itemSpawner;
    private bool itemsSpawned = false;
    private GameObject overlapRoom;

    //Is called when a node is created
    public void CheckIfSpawned()
    {
        //checks if the overlapping room already has items spawned within it
        if (overlapRoom != null && !overlapRoom.GetComponent<PlayerInRoom>().GetSpawnedItems())
        {
            GameObject itemSpawnerInst = Instantiate(itemSpawner, transform.position, Quaternion.identity);
            itemSpawnerInst.transform.parent = overlapRoom.transform;
            itemsSpawned = true;
        }
    }
    private void Update()
    {
        //Sets the rooms item spawned state
        if (itemsSpawned && overlapRoom != null)
        {
            overlapRoom.GetComponent<PlayerInRoom>().SetSpawnedItems(true);
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
