using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    MELEE = 0,
    RANGED = 1,
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
    [SerializeField] private CircleCollider2D aggroCollider;
    [SerializeField] private EnemyType enemyType;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
        currentHealth = maxHealth;

        switch (enemyType)
        {
            case EnemyType.MELEE:
                aggroCollider.radius = 4f;
                break;
            case EnemyType.RANGED:
                aggroCollider.radius = 6f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTowardsTarget != Vector2.zero && Vector2.Distance(transform.position, moveTowardsTarget) > 0.02f)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveTowardsTarget, moveSpeed * Time.deltaTime);
        }    
    }

    public void SetHealth(int HealthEffect, WeaponType TypeEffect)
    {
        switch (enemyType)
        {
            case EnemyType.MELEE:
                if(TypeEffect == WeaponType.RANGED)
                {
                    HealthEffect /= 2;
                }
                break;
            case EnemyType.RANGED:
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

    private void Death(WeaponType TypeEffect)
    {
        killedWeaponType = TypeEffect;
        levelManager.AddEnemyKilledType(TypeEffect);
        Destroy(this.gameObject);
    }
    public EnemyType GetEnemyType()
    {
        return enemyType;
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
