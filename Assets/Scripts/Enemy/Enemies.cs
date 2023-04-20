using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemies : ScriptableObject
{
    public GameObject enemies;
    public string enemyName;
    public int weight;
    public float attackTimer;
    public float moveSpeed;
    public int maxHealth;

    public Enemies(string enemyName, int weight, float attackTimer, float moveSpeed, int maxHealth)
    {
        this.enemyName = enemyName;
        this.weight = weight;
        this.attackTimer = attackTimer;
        this.moveSpeed = moveSpeed;
        this.maxHealth = maxHealth;
    }
}
