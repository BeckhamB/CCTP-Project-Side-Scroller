using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    DEFAULT = 0,
    MELEE = 1,
    RANGED = 2
}
public class PlayerManager : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    private int currentCollectableAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in enemyHit)
        {
            enemy.GetComponent<Enemy>().SetHealth(-40, WeaponType.MELEE);
        }
    }
    
    public void SetCollectableCount(int collectableAmount)
    {
        currentCollectableAmount += collectableAmount;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
