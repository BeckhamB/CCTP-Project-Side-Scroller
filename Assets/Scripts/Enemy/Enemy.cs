using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyWeaponType
{
    MELEE = 0,
    RANGED = 1,
}
public enum EnemyType
{
    GROUNDED = 0,
    FLYING = 1,
}
public class Enemy : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;
    private WeaponType killedWeaponType;
    private LevelManager levelManager;
    private float aggroRadius;
    private float moveSpeed = 2f;
    private Vector2 moveTowardsTarget;
    private Rigidbody2D rb;
    public GameObject meleeEnemyAttackPoint;
    private Vector2 defaultAttackPoint;
    private GameObject rangedAttack;
    private float bulletForce = 10f;
    private float enemyAttackSpeedTimer = 2f;
    private float currentEnemyAttackSpeed;
    private bool hasAttacked;
    private GameObject target;
    [SerializeField] private GameObject rangedAttackPrefab;
    [SerializeField] private CircleCollider2D aggroCollider;
    [SerializeField] private EnemyWeaponType enemyWeaponType;
    [SerializeField] private EnemyType enemyType;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
        currentHealth = maxHealth;

        switch (enemyWeaponType)
        {
            case EnemyWeaponType.MELEE:
                aggroCollider.radius = 4f;
                defaultAttackPoint = meleeEnemyAttackPoint.transform.position;
                break;
            case EnemyWeaponType.RANGED:
                aggroCollider.radius = 6f;
                break;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(currentEnemyAttackSpeed > enemyAttackSpeedTimer)
        {
            RangedAttack();
            currentEnemyAttackSpeed = 0;
        }    
        else
        {
            currentEnemyAttackSpeed += Time.deltaTime;
        }
        
        switch (enemyWeaponType)
        {
            case EnemyWeaponType.MELEE:
                if (moveTowardsTarget != Vector2.zero && Vector2.Distance(transform.position, moveTowardsTarget) > 0.02f)
                {
                    //Vector2 newMoveTowardsTarget = new Vector2(moveTowardsTarget.x, transform.position.y);
                    //transform.position = Vector2.MoveTowards(transform.position, newMoveTowardsTarget, moveSpeed * Time.deltaTime);
                }
                break;
            case EnemyWeaponType.RANGED:
                break;

        }
        

        if(moveTowardsTarget != Vector2.zero && moveTowardsTarget.x > transform.position.x)
        {
            meleeEnemyAttackPoint.transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
        }
        else
        {
            meleeEnemyAttackPoint.transform.position = new Vector2(this.transform.position.x - 1, this.transform.position.y);
        }
        
    }

    public void SetHealth(int HealthEffect, WeaponType TypeEffect)
    {
        switch (enemyWeaponType)
        {
            case EnemyWeaponType.MELEE:
                if(TypeEffect == WeaponType.RANGED)
                {
                    HealthEffect /= 2;
                }
                break;
            case EnemyWeaponType.RANGED:
                if (TypeEffect == WeaponType.MELEE)
                {
                    HealthEffect /= 2;
                }
                break;
        } 
        currentHealth += HealthEffect;
        if(currentHealth <= 0)
        {
            Death(TypeEffect);
        }
    }
    public void EnemyAttack(GameObject targetInRange)
    {
        target = targetInRange;
    }
    private void RangedAttack()
    {
        if (target != null)
        {
            Vector2 direction = new Vector2 (target.transform.position.x - meleeEnemyAttackPoint.transform.position.x, target.transform.position.y - meleeEnemyAttackPoint.transform.position.y + 1f);
            rangedAttack = Instantiate(rangedAttackPrefab, meleeEnemyAttackPoint.transform.position, Quaternion.identity);
            rangedAttack.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized * bulletForce;
            hasAttacked = true;
        }
       
    }
    private void Death(WeaponType TypeEffect)
    {
        killedWeaponType = TypeEffect;
        levelManager.AddEnemyKilledType(TypeEffect);
        Destroy(this.gameObject);
    }
    public EnemyWeaponType GetEnemyType()
    {
        return enemyWeaponType;
    }
    public void MoveTowardsTarget(Vector2 targetPosition)
    {
        moveTowardsTarget = targetPosition;
    }
    public void SetMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }
}
