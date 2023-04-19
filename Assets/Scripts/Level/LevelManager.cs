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
