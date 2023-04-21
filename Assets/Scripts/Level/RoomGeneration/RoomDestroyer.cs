using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
