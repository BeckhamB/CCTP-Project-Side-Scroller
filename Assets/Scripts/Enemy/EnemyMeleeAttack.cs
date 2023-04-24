using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    private PlayerManager playerManager;

    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        StartCoroutine(DestroyTimer());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerManager>().SetHealth(-20, EnemyWeaponType.MELEE);
            Destroy(this.gameObject);
        }
    }
    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
