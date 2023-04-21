using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRoom : MonoBehaviour
{
    private LevelManager levelManager;
    private bool isInRoom;
    public bool hasPlayerEnteredRoomBefore;
    public bool spawnedPlatforms = false;
    public bool spawnedEnemies = false;
    public bool spawnedItems = false;
    public bool timerStopped;
    public float isInRoomTimer = 0f;
    private AddPlatforms[] addPlatforms;
    private AddEnemies[] addEnemies;
    private AddItems[] addItems;

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
        if (addEnemies != null)
        {
            foreach (AddEnemies spawner in addEnemies)
            {
                spawner.CheckIfSpawned();
            }
        }
        if (addItems != null)
        {
            foreach (AddItems spawner in addItems)
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
                if(!timerStopped)
                {
                    isInRoomTimer += Time.deltaTime;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRoom = true;
            addPlatforms = gameObject.GetComponentsInChildren<AddPlatforms>();
            addEnemies = gameObject.GetComponentsInChildren<AddEnemies>();
            addItems = gameObject.GetComponentsInChildren<AddItems>();
            if(!hasPlayerEnteredRoomBefore)
            {
                hasPlayerEnteredRoomBefore = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRoom = false;
        }
    }

    public float GetInRoomTimer()
    {
        return isInRoomTimer;
    }
    public void SetSpawnedPlatforms(bool newState)
    {
        spawnedPlatforms = newState;
    }
    public bool GetSpawnedPlatforms()
    {
        return spawnedPlatforms;
    }
    public void SetSpawnedEnemies(bool newState)
    {
        spawnedEnemies = newState;
    }
    public bool GetSpawnedEnemies()
    {
        return spawnedEnemies;
    }
    public void SetSpawnedItems(bool newState)
    {
        spawnedItems = newState;
    }
    public bool GetSpawnedItems()
    {
        return spawnedItems;
    }
}
