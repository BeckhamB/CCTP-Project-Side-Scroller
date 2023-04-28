using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used to fix a problem within the generation
//When two rooms are instantiating at the same time neither are created
//Therefore, when that happens this spawns a closed room and then
//Destroys the node
public class RoomDestroyer : MonoBehaviour
{
    private GameObject overlapRoom;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInRoom>() != null)
        {
            overlapRoom = collision.gameObject;

        }
        if (collision.CompareTag("ClosedWall") && overlapRoom != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
