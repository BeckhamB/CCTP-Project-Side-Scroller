using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    private Enemy enemyScript;
    private EnemyWeaponType currentEnemyType;
    private void Start()
    {
        enemyScript = GetComponentInParent<Enemy>();
        currentEnemyType = enemyScript.GetEnemyType();
    }
    private void Update()
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (currentEnemyType)
            {
                case EnemyWeaponType.MELEE:
                    enemyScript.MoveTowardsTarget(collision.transform.position);
                    break;
                case EnemyWeaponType.RANGED:
                    enemyScript.MoveTowardsTarget(collision.transform.position);
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            switch(currentEnemyType)
            {
                case EnemyWeaponType.MELEE:
                    break;
                case EnemyWeaponType.RANGED:
                    enemyScript.EnemyAttack(collision.gameObject);
                    break;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (currentEnemyType)
            {
                case EnemyWeaponType.MELEE:
                    break;
                case EnemyWeaponType.RANGED:
                    enemyScript.EnemyAttack(null);
                    break;

            }


        }
    }
}