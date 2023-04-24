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
    private float moveSpeed = 2f;
    private Vector2 moveTowardsTarget;
    public GameObject enemyAttackPoint;
    private Vector2 defaultAttackPoint;
    private GameObject meleeAttack;
    private GameObject rangedAttack;
    private float bulletForce = 10f;
    private float enemyAttackSpeedTimer = 2f;
    private float currentEnemyAttackSpeed;
    private bool hasAttacked;
    private GameObject target;
    private GameObject overlapRoom;
    private Vector2 originalPosition;
    [SerializeField] private GameObject meleeAttackPrefab;
    [SerializeField] private GameObject rangedAttackPrefab;
    [SerializeField] private CircleCollider2D aggroCollider;
    [SerializeField] private EnemyWeaponType enemyWeaponType;
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = this.gameObject.transform.position;
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
        currentHealth = maxHealth;

        switch (enemyWeaponType)
        {
            case EnemyWeaponType.MELEE:
                aggroCollider.radius = 4f;
                defaultAttackPoint = enemyAttackPoint.transform.position;
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
            switch(enemyWeaponType)
            {
                case EnemyWeaponType.MELEE:
                    MeleeAttack();
                    break;
                case EnemyWeaponType.RANGED:
                    RangedAttack();
                    break;
            }
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
                    Vector2 newMoveTowardsTarget = new Vector2(moveTowardsTarget.x, transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, newMoveTowardsTarget, moveSpeed * Time.deltaTime);
                }
                break;
            case EnemyWeaponType.RANGED:
                break;

        }
        

        if(moveTowardsTarget != Vector2.zero && moveTowardsTarget.x > transform.position.x)
        {
            enemyAttackPoint.transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
        }
        else
        {
            enemyAttackPoint.transform.position = new Vector2(this.transform.position.x - 1, this.transform.position.y);
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
    private void MeleeAttack()
    {
        if (target != null)
        {
            Vector2 direction = new Vector2(target.transform.position.x - enemyAttackPoint.transform.position.x, target.transform.position.y - enemyAttackPoint.transform.position.y + 0.6f);
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction, aggroCollider.radius, layerMask);

            if (hit.collider != null)
            {
                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    meleeAttack = Instantiate(meleeAttackPrefab, enemyAttackPoint.transform.position, Quaternion.identity);
                    meleeAttack.transform.parent = this.gameObject.transform;
                    hasAttacked = true;
                }
            }

        }

    }
    private void RangedAttack()
    {
        if (target != null)
        {
            Vector2 direction = new Vector2(target.transform.position.x - enemyAttackPoint.transform.position.x, target.transform.position.y - enemyAttackPoint.transform.position.y + 0.6f);
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction, aggroCollider.radius, layerMask);

            if (hit.collider != null)
            {
                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    rangedAttack = Instantiate(rangedAttackPrefab, enemyAttackPoint.transform.position, Quaternion.identity);
                    rangedAttack.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized * bulletForce;
                    hasAttacked = true;
                }
            }

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
        if(targetPosition != Vector2.zero)
        {
            Vector2 direction = new Vector2(targetPosition.x - enemyAttackPoint.transform.position.x, targetPosition.y - enemyAttackPoint.transform.position.y + 0.6f);
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction, aggroCollider.radius, layerMask);

            if (hit.collider != null)
            {
                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    moveTowardsTarget = targetPosition;
                }
            }
        }
    }
    public void SetMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInRoom>() != null && overlapRoom == null)
        {
            overlapRoom = collision.gameObject;

        }
    }

}
