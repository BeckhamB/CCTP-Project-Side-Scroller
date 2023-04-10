using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRoom : MonoBehaviour
{
    private LevelManager levelManager;
    private bool isInRoom;
    private float isInRoomTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isInRoom)
        {
            if (!levelManager.AreAllEnemiesDead())
            {
                isInRoomTimer += Time.deltaTime;
            }
        }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isInRoom = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInRoom = false;
        }
    }

    public float GetInRoomTimer()
    {
        return isInRoomTimer;
    }
}
