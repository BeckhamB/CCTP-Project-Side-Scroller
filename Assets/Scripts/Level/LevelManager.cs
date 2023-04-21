using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool allEnemiesDead = false;
    private int enemiesKilledInRoom;
    private int meleeHitTracker;
    private int rangedHitTracker;
    private int meleeKills;
    private int rangedKills;
    private int collectablesPickedUp;
    private int maxWeight = 400;
    public int maxNumOfRooms = 10;

    private RoomTemplate roomTemplate;
    private PlatformGenerator platformGenerator;
    private EnemyGenerator enemyGenerator;

    private bool increaseMeleeEnemyPrompt1 = false;
    private bool increaseRangedEnemyPrompt1 = false;
    private bool increaseMeleeKills1 = false;
    private bool increaseRangedKills1 = false;

    private void Start()
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

        if (meleeHitTracker - rangedHitTracker == 5 && !increaseMeleeEnemyPrompt1)
        {
            for (int i = 0; i < enemyGenerator.enemies.Count; i++)
            {
                if (enemyGenerator.enemies[i].enemyName == "GroundedMeleeEnemy")
                {
                    Debug.Log("Increased Melee Enemy Spawn Rate");
                    enemyGenerator.enemies[i].weight += 100;
                }
            }
            increaseMeleeEnemyPrompt1 = true;
        }
        if (meleeHitTracker - rangedHitTracker == -5 && !increaseRangedEnemyPrompt1)
        {
            for (int i = 0; i < enemyGenerator.enemies.Count; i++)
            {
                if (enemyGenerator.enemies[i].enemyName == "GroundedRangedEnemy")
                {
                    Debug.Log("Increased Ranged Enemy Spawn Rate");
                    enemyGenerator.enemies[i].weight += 100;
                }
            }
            increaseRangedEnemyPrompt1 = true;
        }
        if (meleeKills == 10 && !increaseMeleeKills1)
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
            increaseMeleeKills1 = true;
        }
        if (rangedKills == 10 && !increaseRangedKills1)
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
    public void AddPickedUpCollectable()
    {
        collectablesPickedUp++;
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
}
