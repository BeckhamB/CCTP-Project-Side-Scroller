using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    private Enemy enemyScript;
    private EnemyType currentEnemyType;
    private void Start()
    {
        enemyScript = GetComponentInParent<Enemy>();
        currentEnemyType = enemyScript.GetEnemyType();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            switch(currentEnemyType)
            {
                case EnemyType.MELEE:
                    enemyScript.MoveTowardsTarget(collision.transform.position);
                    break;
                case EnemyType.RANGED:
                    break;
            }
        }
    }
}
