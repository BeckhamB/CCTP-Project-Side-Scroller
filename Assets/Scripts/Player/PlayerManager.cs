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
    private int currentHealth;
    private int maxHealth = 100;
    private int currentCollectableAmount;
    private LevelManager levelManager;
    private HeroKnight heroKnight;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
        heroKnight = GetComponent<HeroKnight>();
    }

    public void Attack()
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in enemyHit)
        {
            levelManager.SetMeleeHitTracker(1);
            enemy.GetComponent<Enemy>().SetHealth(-40, WeaponType.MELEE);
        }
    }
    
    public void SetCollectableCount(int collectableAmount)
    {
        currentCollectableAmount += collectableAmount;
    }
    
    public void SetHealth(int HealthEffect, EnemyWeaponType TypeEffect)
    {
        if(HealthEffect < 0)
        {
            heroKnight.TakeDamage();
        }
        currentHealth += HealthEffect;
    }
        private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
