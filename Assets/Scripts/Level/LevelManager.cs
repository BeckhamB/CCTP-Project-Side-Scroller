using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool allEnemiesDead = false;
    private int numberOfCollectablesSpawned;
    private int numberOfEnemiesSpawned;

    private int enemiesKilledInRoom;
    private int meleeHitTracker;
    private int rangedHitTracker;
    private int meleeKills;
    private int rangedKills;
    private int totalKills;
    private int collectablesPickedUp;

    private int maxWeight = 400;
    public int maxNumOfRooms = 10;


    private RoomTemplate roomTemplate;
    private PlatformGenerator platformGenerator;
    private EnemyGenerator enemyGenerator;
    private ItemGenerator itemGenerator;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (platformGenerator == null && GameObject.FindGameObjectWithTag("PlatformManager") != null)
        {
            platformGenerator = GameObject.FindGameObjectWithTag("PlatformManager").GetComponentInChildren<PlatformGenerator>();

        }
        if (enemyGenerator == null && GameObject.FindGameObjectWithTag("EnemyManager") != null)
        {
            enemyGenerator = GameObject.FindGameObjectWithTag("EnemyManager").GetComponentInChildren<EnemyGenerator>();
        }

        if (itemGenerator == null && GameObject.FindGameObjectWithTag("ItemManager") != null)
        {
            itemGenerator = GameObject.FindGameObjectWithTag("ItemManager").GetComponentInChildren<ItemGenerator>();
        }

        NumberOfPlayerHitsCheck();
        NumberOfPlayerKillsCheck();
    }
    public void CollectCoinsInLevelCheck()
    {
        if (numberOfCollectablesSpawned != 0)
        {
            if (collectablesPickedUp / numberOfCollectablesSpawned > 0.7 )
            {
                for (int i = 0; i < itemGenerator.items.Count; i++)
                {
                    if (itemGenerator.items[i].itemName == "Coin")
                    {
                        Debug.Log("Increased Coin Spawn Rate for % of coins");
                        itemGenerator.items[i].weight += 10;
                        if(maxNumOfRooms < 13)
                        {
                            maxNumOfRooms++;
                        }
                    }
                }
            }
        }
        if (numberOfCollectablesSpawned != 0)
        {
            if (collectablesPickedUp / numberOfCollectablesSpawned < 0.3)
            {
                for (int i = 0; i < itemGenerator.items.Count; i++)
                {
                    if (itemGenerator.items[i].itemName == "Coin")
                    {
                        Debug.Log("Decreased Coin Spawn Rate for % of coins");
                        itemGenerator.items[i].weight -= 10;
                        if (maxNumOfRooms > 7)
                        {
                            maxNumOfRooms--;
                        }
                    }
                }
            }
        }
        if (numberOfCollectablesSpawned != 0)
        {
            if (collectablesPickedUp == numberOfCollectablesSpawned)
            {
                for (int i = 0; i < itemGenerator.items.Count; i++)
                {
                    if (itemGenerator.items[i].itemName == "Coin")
                    {
                        Debug.Log("Increased Coin Spawn Rate for collecting all coins");
                        itemGenerator.items[i].weight += 25;
                    }
                }

            }
        }
        numberOfCollectablesSpawned = 0;
        collectablesPickedUp = 0;
    }
    public void KilledEnemiesInLevelCheck()
    {
        totalKills = meleeKills + rangedKills;
        if(totalKills / numberOfEnemiesSpawned > 0.7)
        {
            for (int i = 0; i < enemyGenerator.enemies.Count; i++)
            {
                if (enemyGenerator.enemies[i].enemyName == "GroundedRangedEnemy")
                {
                    Debug.Log("Increased Ranged Enemy Spawn Rate");
                    enemyGenerator.enemies[i].weight += 100;
                }
                if (enemyGenerator.enemies[i].enemyName == "GroundedMeleeEnemy")
                {
                    Debug.Log("Increased Melee Enemy Spawn Rate");
                    enemyGenerator.enemies[i].weight += 100;
                }

            }
        }
        if (totalKills / numberOfEnemiesSpawned < 0.7)
        {
            for (int i = 0; i < enemyGenerator.enemies.Count; i++)
            {
                if (enemyGenerator.enemies[i].enemyName == "GroundedRangedEnemy")
                {
                    Debug.Log("Increased Ranged Enemy Spawn Rate");
                    enemyGenerator.enemies[i].weight -= 100;
                }
                if (enemyGenerator.enemies[i].enemyName == "GroundedMeleeEnemy")
                {
                    Debug.Log("Increased Melee Enemy Spawn Rate");
                    enemyGenerator.enemies[i].weight -= 100;
                }

            }
        }
        if(totalKills == numberOfEnemiesSpawned)
        {
            for (int i = 0; i < enemyGenerator.enemies.Count; i++)
            {
                if (enemyGenerator.enemies[i].enemyName == "GroundedRangedEnemy")
                {
                    Debug.Log("Increased Ranged Enemy Spawn Rate and Attack Speed");
                    enemyGenerator.enemies[i].weight += 150;
                }
                if (enemyGenerator.enemies[i].enemyName == "GroundedMeleeEnemy")
                {
                    Debug.Log("Increased Melee Enemy Spawn Rate and AttackSpeed");
                    enemyGenerator.enemies[i].weight += 150;
                }

            }
        }
    }
    public void AdjustPlatform1Weight(int addValue)
    {
        for (int i = 0; i < platformGenerator.platforms.Count; i++)
        {
            if (platformGenerator.platforms[i].platformName == "LargePlatform")
            {
                Debug.Log("Affect Large Platform Spawn Rate");
                platformGenerator.platforms[i].weight += addValue;
            }
        }
    }
    public void AdjustPlatform2Weight(int addValue)
    {
        for (int i = 0; i < platformGenerator.platforms.Count; i++)
        {
            if (platformGenerator.platforms[i].platformName == "SmallPlatform")
            {
                Debug.Log("Affect Small Platform Spawn Rate");
                platformGenerator.platforms[i].weight += addValue;
            }
        }
    }
    public void AdjustPlatform3Weight(int addValue)
    {
        for (int i = 0; i < platformGenerator.platforms.Count; i++)
        {
            if (platformGenerator.platforms[i].platformName == "FallingPlatform")
            {
                Debug.Log("Affect Falling Platform Spawn Rate");
                platformGenerator.platforms[i].weight += addValue;
            }
        }
    }
    public void AdjustPlatform4Weight(int addValue)
    {
        for (int i = 0; i < platformGenerator.platforms.Count; i++)
        {
            if (platformGenerator.platforms[i].platformName == "MovingPlatform")
            {
                Debug.Log("Affect Moving Platform Spawn Rate");
                platformGenerator.platforms[i].weight += addValue;
            }
        }
    }
    public void AdjustMeleeEnemySpawnRate(float addMoveSpeedValue, float addAttackSpeedValue)
    {
        if(enemyGenerator != null)
        {
            for (int i = 0; i < enemyGenerator.enemies.Count; i++)
            {
                if (enemyGenerator.enemies[i].enemyName == "GroundedMeleeEnemy")
                {
                    Debug.Log("Adjusted Melee Enemy Spawn Rate");
                    enemyGenerator.enemies[i].attackTimer += addAttackSpeedValue;
                    enemyGenerator.enemies[i].moveSpeed += addMoveSpeedValue;
                }
            }
        }
    }
    public void AdjustRangedEnemySpawnRate(float addMoveSpeedValue, float addAttackSpeedValue)
    {
        if(enemyGenerator != null)
        {
            for (int i = 0; i < enemyGenerator.enemies.Count; i++)
            {
                if (enemyGenerator.enemies[i].enemyName == "GroundedRangedEnemy")
                {
                    Debug.Log("Adjusted Ranged Enemy Spawn Rate");
                    enemyGenerator.enemies[i].attackTimer += addAttackSpeedValue;
                    enemyGenerator.enemies[i].moveSpeed += addMoveSpeedValue;
                }
            }
        }    
    }
    private void NumberOfPlayerHitsCheck()
    {
        if (meleeHitTracker - rangedHitTracker == 10)
        {
            for (int i = 0; i < enemyGenerator.enemies.Count; i++)
            {
                if (enemyGenerator.enemies[i].enemyName == "GroundedMeleeEnemy")
                {
                    Debug.Log("Increased Melee Enemy Spawn Rate");
                    enemyGenerator.enemies[i].weight += 100;
                }
            }
            meleeHitTracker = 0;
            rangedHitTracker = 0;
        }
        if (meleeHitTracker - rangedHitTracker == -10)
        {
            for (int i = 0; i < enemyGenerator.enemies.Count; i++)
            {
                if (enemyGenerator.enemies[i].enemyName == "GroundedRangedEnemy")
                {
                    Debug.Log("Increased Ranged Enemy Spawn Rate");
                    enemyGenerator.enemies[i].weight += 100;
                }
            }
            meleeHitTracker = 0;
            rangedHitTracker = 0;
        }
    }
    private void NumberOfPlayerKillsCheck()
    {
        if (meleeKills - rangedKills == 10)
        {
            for (int i = 0; i < enemyGenerator.enemies.Count; i++)
            {
                if (enemyGenerator.enemies[i].enemyName == "GroundedMeleeEnemy")
                {
                    Debug.Log("Increased Melee Enemy Spawn Rate AND Attack Speed");
                    enemyGenerator.enemies[i].weight += 150;
                    enemyGenerator.enemies[i].attackTimer -= 1f;
                }
            }
            meleeKills = 0;
            rangedKills = 0;
        }
        if (meleeKills - rangedKills == -10)
        {
            for (int i = 0; i < enemyGenerator.enemies.Count; i++)
            {
                if (enemyGenerator.enemies[i].enemyName == "GroundedRangedEnemy")
                {
                    Debug.Log("Increased Ranged Enemy Spawn Rate AND Attack Speed");
                    enemyGenerator.enemies[i].weight += 150;
                    enemyGenerator.enemies[i].attackTimer -= 1f;
                }
            }
            meleeKills = 0;
            rangedKills = 0;
        }


    }
    public void AddEnemyKilledType(WeaponType killedType)
    {
        if(killedType == WeaponType.MELEE)
        {
            meleeKills++;
            enemiesKilledInRoom++;
        }
        else if(killedType == WeaponType.RANGED)
        {
            rangedKills++;
            enemiesKilledInRoom++;
        }
    }
    public void SetNumCollectableSpawned(int addValue)
    {
        numberOfCollectablesSpawned += addValue;
    }
    public void AddPickedUpCollectable()
    {
        collectablesPickedUp++;
    }
    public void SetNumEnemySpawned(int addValue)
    {
        numberOfEnemiesSpawned += addValue;
    }
    public bool AreAllEnemiesDead()
    {
        return allEnemiesDead;
    }
    public void SetMeleeHitTracker(int hitAmount)
    {
         meleeHitTracker += hitAmount;
    }
    public void SetRangedHitTracker(int hitAmount)
    {
        rangedHitTracker += hitAmount;
    }
    public int TotalMaxNumOfRooms()
    {
        return maxNumOfRooms;
    }
    public int GetNumOfCollectablesSpawned()
    {
        return numberOfCollectablesSpawned;
    }
    public int GetNumOfEnemiesSpawned()
    {
        return numberOfEnemiesSpawned;
    }
    public int GetNumOfMeleeHits()
    {
        return meleeHitTracker;
    }
    public int GetNumOfRangedHits()
    {
        return rangedHitTracker;
    }
    public int GetNumOfMeleeKills()
    {
        return meleeKills;
    }
    public int GetNumOfRangedKills()
    {
        return rangedKills;
    }
    public int GetNumOfCoinsPickedUp()
    {
        return collectablesPickedUp;
    }
    public void ResetValues()
    {
        numberOfCollectablesSpawned = 0;
        numberOfEnemiesSpawned = 0;
        meleeKills = 0;
        rangedKills = 0;
        totalKills = 0;
        meleeHitTracker = 0;
        rangedHitTracker = 0;
        collectablesPickedUp = 0;
    }
}
