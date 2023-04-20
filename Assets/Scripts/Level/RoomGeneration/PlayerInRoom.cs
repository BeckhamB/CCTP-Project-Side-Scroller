using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRoom : MonoBehaviour
{
    private LevelManager levelManager;
    private bool isInRoom;
    private bool hasPlayerEnteredRoomBefore;
    public bool spawnedObjects = false;
    private float isInRoomTimer = 0f;
    private AddPlatforms[] addPlatforms;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
    }

    private void Update()
    {
        if (addPlatforms != null)
        {
            foreach (AddPlatforms spawner in addPlatforms)
            {
                spawner.CheckIfSpawned();
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isInRoom)
        {
            if (!levelManager.AreAllEnemiesDead())
            {
                isInRoomTimer += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRoom = true;
            addPlatforms = gameObject.GetComponentsInChildren<AddPlatforms>(); 
            if(!hasPlayerEnteredRoomBefore)
            {
                hasPlayerEnteredRoomBefore = true;
            }
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
    public void SetSpawnedObjects(bool newState)
    {
        spawnedObjects = newState;
    }
    public bool GetSpawnedObjects()
    {
        return spawnedObjects;
    }
}
