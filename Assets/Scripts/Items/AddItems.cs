using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItems : MonoBehaviour
{
    public GameObject itemSpawner;
    private bool itemsSpawned = false;
    private GameObject overlapRoom;

    public void CheckIfSpawned()
    {
        if (overlapRoom != null && !overlapRoom.GetComponent<PlayerInRoom>().GetSpawnedItems())
        {
            GameObject itemSpawnerInst = Instantiate(itemSpawner, transform.position, Quaternion.identity);
            itemSpawnerInst.transform.parent = overlapRoom.transform;
            itemsSpawned = true;
        }
    }
    private void Update()
    {
        if (itemsSpawned && overlapRoom != null)
        {
            overlapRoom.GetComponent<PlayerInRoom>().SetSpawnedItems(true);
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
