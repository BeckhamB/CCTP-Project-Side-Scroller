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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
