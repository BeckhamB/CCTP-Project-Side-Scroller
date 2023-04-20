using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool allEnemiesDead = false;
    private int enemiesKilledInRoom;
    private int meleeKills;
    private int rangedKills;
    private int collectablesPickedUp;
    public int maxNumOfRooms = 10;

    private RoomTemplate roomTemplate;
    private PlatformGenerator platformGenerator;
    private EnemyGenerator enemyGenerator;

    private void Start()
    {
        
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        /*if (roomTemplate == null && GameObject.FindGameObjectWithTag("Rooms") != null)
        {
            roomTemplate = GameObject.FindGameObjectWithTag("Rooms").GetComponentInChildren<RoomTemplate>();
        }*/
        if (platformGenerator == null && GameObject.FindGameObjectWithTag("PlatformManager") != null)
        {
            platformGenerator = GameObject.FindGameObjectWithTag("PlatformManager").GetComponentInChildren<PlatformGenerator>();
            
        }
        if(enemyGenerator == null && GameObject.FindGameObjectWithTag("EnemyManager") != null)
        {
            enemyGenerator = GameObject.FindGameObjectWithTag("EnemyManager").GetComponentInChildren<EnemyGenerator>();
        }

        /*for(int i = 0; i < enemyGenerator.enemies.Count; i++)
        {
            if(enemyGenerator.enemies[i].enemyName == "GroundedMeleeEnemy")
            {
                enemyGenerator.enemies[i].weight = 10000;
            }
        }*/
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
    public int TotalMaxNumOfRooms()
    {
        return maxNumOfRooms;
    }
}
