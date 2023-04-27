using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [Header("Level Manager Values")]
    [SerializeField] private TextMeshProUGUI numOfCoinsSpawnedText;
    [SerializeField] private TextMeshProUGUI numOfEnemiesText;
    [SerializeField] private TextMeshProUGUI numOfMeleeHitsText;
    [SerializeField] private TextMeshProUGUI numOfRangedHitsText;
    [SerializeField] private TextMeshProUGUI numOfMeleeKillsText;
    [SerializeField] private TextMeshProUGUI numOfRangedKillsText;
    [SerializeField] private TextMeshProUGUI numOfCoinsPickedUp;

    [Header("Room Manager Values")]
    [SerializeField] private TextMeshProUGUI timeSpentText;
    [SerializeField] private TextMeshProUGUI numOfCoinsInRoomText;
    [SerializeField] private TextMeshProUGUI numOfEnemiesInRoomText;
    [SerializeField] private TextMeshProUGUI numOfCoinsCollectedText;
    [SerializeField] private TextMeshProUGUI numOfEnemiesKilledText;
    [SerializeField] private TextMeshProUGUI numOfMeleeHitsTakenText;
    [SerializeField] private TextMeshProUGUI numOfRangedHitsTakenText;

    [Header("Scriptable Object Values")]
    [SerializeField] private TextMeshProUGUI largePlatformWeightText;
    [SerializeField] private TextMeshProUGUI smallPlatformWeightText;
    [SerializeField] private TextMeshProUGUI fallingPlatformWeightText;
    [SerializeField] private TextMeshProUGUI movingPlatformWeightText;
    [SerializeField] private TextMeshProUGUI coinWeightText;
    [SerializeField] private TextMeshProUGUI meleeEnemyAttackSpeedText;
    [SerializeField] private TextMeshProUGUI meleeEnemyMoveSpeedText;
    [SerializeField] private TextMeshProUGUI meleeEnemyWeightText;
    [SerializeField] private TextMeshProUGUI rangedEnemyAttackSpeedText;
    [SerializeField] private TextMeshProUGUI rangedEnemyMoveSpeedText;
    [SerializeField] private TextMeshProUGUI rangedEnemyWeightText;

    [Header("Scriptable Objects")]
    [SerializeField] private Platforms largePlatformSO;
    [SerializeField] private Platforms smallPlatformSO;
    [SerializeField] private Platforms fallingPlatformSO;
    [SerializeField] private Platforms movingPlatformSO;
    [SerializeField] private Items coinSO;
    [SerializeField] private Enemies meleeEnemySO;
    [SerializeField] private Enemies rangedEnemySO;

    [Header("Managers")]
    private LevelManager levelManager;
    private PlayerInRoom[] spawnedRooms;
    private GameObject portal;
    private bool getRooms = false;
   


    // Update is called once per frame
    void Update()
    {
        if(levelManager == null)
        {
            levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
        }
        if(portal == null)
        {
            portal = GameObject.FindGameObjectWithTag("Portal");
        }
        if(portal != null && !getRooms)
        {
            spawnedRooms = GameObject.FindObjectsOfType<PlayerInRoom>();
            getRooms = true;
        }
        UpdateLevelManagerValues();
        UpdateRoomManagerValues();
        UpdateScriptableObjectValues();
    }

    private void UpdateLevelManagerValues()
    {
        numOfCoinsSpawnedText.text = "Number of Coins Spawned: " + levelManager.GetNumOfCollectablesSpawned();
        numOfEnemiesText.text = "Number of Enemies Spawned: " + levelManager.GetNumOfEnemiesSpawned();
        numOfMeleeHitsText.text = "Number of Melee Hits: " + levelManager.GetNumOfMeleeHits();
        numOfRangedHitsText.text = "Number of Ranged Hits: " + levelManager.GetNumOfRangedHits();
        numOfMeleeKillsText.text = "Number of Melee Kills: " + levelManager.GetNumOfMeleeKills();
        numOfRangedKillsText.text = "Number of Ranged Kills: " + levelManager.GetNumOfRangedKills();
        numOfCoinsPickedUp.text = "Number of Coins Picked Up: " + levelManager.GetNumOfCoinsPickedUp();
    }
    private void UpdateRoomManagerValues()
    {
        if(spawnedRooms != null)
        {
            foreach (PlayerInRoom script in spawnedRooms)
            {
                if (script.GetIsPlayerInRoom())
                {
                    timeSpentText.text = "Time Spent in Room:  " + script.GetInRoomTimer().ToString("0.00");
                    numOfCoinsInRoomText.text = "Number of Coins in Room:  " + script.GetNumOfCoinsSpawned();
                    numOfEnemiesInRoomText.text = "Number of Enemies in Room:  " + script.GetNumOfSpawnedEnemies();
                    numOfCoinsCollectedText.text = "Number of Coins Collected in Room:  " + script.GetNumOfCoinsCollected();
                    numOfEnemiesKilledText.text = "Number of Enemies Killed in Room:  " + script.GetNumOfEnemiesKilled();
                    numOfMeleeHitsTakenText.text = "Number of Melee Hits Taken in Room:  " + script.GetNumOfMeleeHitsTaken();
                    numOfRangedHitsTakenText.text = "Number of Ranged Hits Taken in Room:  " + script.GetNumOfRangedHitsTaken();
                }
            }
        }
    }
    private void UpdateScriptableObjectValues()
    {
        largePlatformWeightText.text = "Large Platform Weight: " + largePlatformSO.weight;
        smallPlatformWeightText.text = "Small Platform Weight: " + smallPlatformSO.weight;
        fallingPlatformWeightText.text = "Falling Platform Weight: " + fallingPlatformSO.weight;
        movingPlatformWeightText.text = "Moving Platform Weight: " + movingPlatformSO.weight;
        coinWeightText.text = "Coin Weight: " + coinSO.weight;
        meleeEnemyAttackSpeedText.text = "Melee Enemy Attack Speed: " + meleeEnemySO.attackTimer;
        meleeEnemyMoveSpeedText.text = "Melee Enemy Move Speed: " + meleeEnemySO.moveSpeed;
        meleeEnemyWeightText.text = "Melee Enemy Weight: " + meleeEnemySO.weight;
        rangedEnemyAttackSpeedText.text = "Ranged Enemy Attack Speed: " + rangedEnemySO.attackTimer;
        rangedEnemyMoveSpeedText.text = "Ranged Enemy Move Speed: " + rangedEnemySO.moveSpeed;
        rangedEnemyWeightText.text = "Ranged Enemy Weight: " + rangedEnemySO.weight;
    }
}
