using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRoom : MonoBehaviour
{
    private LevelManager levelManager;
    private bool isInRoom;
    private bool hasPlayerEnteredRoomBefore;
    public bool spawnedPlatforms = false;
    public bool spawnedEnemies = false;
    private float isInRoomTimer = 0f;
    private AddPlatforms[] addPlatforms;
    private AddEnemies[] addEnemies;

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
            addEnemies = gameObject.GetComponentsInChildren<AddEnemies>();
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
    public bool GetSpawnedEnemiess()
    {
        return spawnedEnemies;
    }
}
