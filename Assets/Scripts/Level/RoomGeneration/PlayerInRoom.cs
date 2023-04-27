using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRoom : MonoBehaviour
{
    private LevelManager levelManager;
    private bool isInRoom = false;
    public bool hasPlayerEnteredRoomBefore;
    public bool spawnedPlatforms = false;
    public bool spawnedEnemies = false;
    public bool spawnedItems = false;
    public bool timerStopped;
    public float isInRoomTimer = 0f;
    private int numOfCoinsInRoom = 0;
    private int numOfEnemiesInRoom = 0;
    private int numOfCoinsCollected = 0;
    private int numOfEnemiesKilled = 0;
    private int numOfMeleeHitsTaken = 0;
    private int numOfRangedHitsTaken = 0;
    private AddPlatforms[] addPlatforms;
    private AddEnemies[] addEnemies;
    private AddItems[] addItems;

    private bool checkedCoinCount = false;
    private bool checkedHitCount = false;
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
        CheckCoinCollected();
        CheckHitsTaken();
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
    private void CheckCoinCollected()
    {
        if(!checkedCoinCount)
        {
            if (numOfCoinsInRoom != 0)
            {
                if (isInRoomTimer >= 40f || numOfCoinsCollected == numOfCoinsInRoom)
                {
                    if (numOfCoinsCollected == numOfCoinsInRoom)
                    {
                        levelManager.AdjustPlatform3Weight(15);
                        levelManager.AdjustPlatform4Weight(10);
                    }
                    if (numOfCoinsCollected / numOfCoinsInRoom > 0.7)
                    {
                        levelManager.AdjustPlatform3Weight(10);
                        levelManager.AdjustPlatform1Weight(-10);
                    }
                    if (numOfCoinsCollected / numOfCoinsInRoom < 0.3)
                    {
                        levelManager.AdjustPlatform3Weight(-10);
                        levelManager.AdjustPlatform1Weight(10);
                    }
                    if(numOfCoinsCollected == 0)
                    {
                        levelManager.AdjustPlatform2Weight(10);
                        levelManager.AdjustPlatform1Weight(10);

                    }
                    checkedCoinCount = true;
                }
            }
        }
    }
    private void CheckHitsTaken()
    {
        if (!checkedHitCount)
        {
            if(numOfEnemiesInRoom != 0)
            {
                if (isInRoomTimer >= 40f || numOfEnemiesKilled == numOfEnemiesInRoom)
                {
                    if (numOfMeleeHitsTaken == 0)
                    {
                        levelManager.AdjustMeleeEnemySpawnRate(0.2f, -0.2f);
                    }
                    if (numOfMeleeHitsTaken < 3)
                    {
                        levelManager.AdjustMeleeEnemySpawnRate(0.1f, -0.1f);
                    }
                    if (numOfMeleeHitsTaken > 7)
                    {
                        levelManager.AdjustMeleeEnemySpawnRate(-0.1f, 0.1f);
                    }
                    if (numOfRangedHitsTaken == 0)
                    {
                        levelManager.AdjustRangedEnemySpawnRate(0.2f, -0.2f);
                    }
                    if (numOfRangedHitsTaken < 3)
                    {
                        levelManager.AdjustRangedEnemySpawnRate(0.1f, -0.1f);
                    }
                    if (numOfRangedHitsTaken > 7)
                    {
                        levelManager.AdjustRangedEnemySpawnRate(-0.1f, 0.1f);
                    }
                    checkedHitCount = true;
                }
            } 
        }
    }
    public void CoinSpawned(int addValue)
    {
        numOfCoinsInRoom += addValue;
    }
    public void EnemiesSpawned(int addValue)
    {
        numOfEnemiesInRoom += addValue;
    }
    public void CoinCollected(int addValue)
    {
        numOfCoinsCollected += addValue;
    }
    public void EnemiesKilled(int addValue)
    {
        numOfEnemiesKilled += addValue;
    }
    public void PlayerMeleeHitsTaken(int addValue)
    {
        numOfMeleeHitsTaken += addValue;
    }
    public void PlayerRangedHitsTaken(int addValue)
    {
        numOfRangedHitsTaken += addValue;
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

    public bool GetIsPlayerInRoom()
    {
        return isInRoom;
    }
    public int GetNumOfCoinsSpawned()
    {
        return numOfCoinsInRoom;
    }
    public int GetNumOfSpawnedEnemies()
    {
        return numOfEnemiesInRoom;
    }
    public int GetNumOfCoinsCollected()
    {
        return numOfCoinsCollected;
    }
    public int GetNumOfEnemiesKilled()
    {
        return numOfEnemiesKilled;
    }
    public int GetNumOfMeleeHitsTaken()
    {
        return numOfMeleeHitsTaken;
    }
    public int GetNumOfRangedHitsTaken()
    {
        return numOfRangedHitsTaken;
    }
}
