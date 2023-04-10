using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;
    private WeaponType killedWeaponType;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetHealth(int HealthEffect, WeaponType TypeEffect)
    {
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

}
