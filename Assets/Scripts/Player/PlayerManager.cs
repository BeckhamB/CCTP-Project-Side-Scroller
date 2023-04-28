using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum for the different weapon types the player uses
public enum WeaponType
{
    DEFAULT = 0,
    MELEE = 1,
    RANGED = 2
}

//This script manages the players combative functionality within the game
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
    private GameObject canvas;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
        heroKnight = GetComponent<HeroKnight>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        canvas.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            //displays the UI 
            canvas.SetActive(!canvas.activeSelf);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void Attack()
    {
        //affects all enemies within the circle collider
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in enemyHit)
        {
            //Affects the level manager values
            levelManager.SetMeleeHitTracker(1);
            enemy.GetComponent<Enemy>().SetHealth(-40, WeaponType.MELEE);
        }
    }
    
    public void SetCollectableCount(int collectableAmount)
    {
        currentCollectableAmount += collectableAmount;
    }
    
    //Is called when the player is hit by an enemy
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
