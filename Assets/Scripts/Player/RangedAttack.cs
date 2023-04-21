using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            levelManager.SetRangedHitTracker(1);
            collision.GetComponent<Enemy>().SetHealth(-20, WeaponType.RANGED);
            Destroy(this.gameObject);
        }
    }
}
