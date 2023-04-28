using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is used when the player ranged attack is instantiated
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
            //Also affects the level manager values
            levelManager.SetRangedHitTracker(1);
            collision.GetComponent<Enemy>().SetHealth(-40, WeaponType.RANGED);
            Destroy(this.gameObject);
        }
    }
}
