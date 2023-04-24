using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private LevelManager levelManager;
    private PlayerInRoom overlapRoom;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
        overlapRoom = GetComponentInParent<PlayerInRoom>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && overlapRoom != null)
        {
            collision.GetComponent<PlayerManager>().SetCollectableCount(1);
            overlapRoom.CoinCollected(1);
            levelManager.AddPickedUpCollectable();
            Destroy(this.gameObject);
        }
    }
}
