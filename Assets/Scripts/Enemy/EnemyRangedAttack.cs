using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    private PlayerManager playerManager;

    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerManager>().SetHealth(-20, EnemyWeaponType.RANGED);
            Destroy(this.gameObject);
        }
    }
}
