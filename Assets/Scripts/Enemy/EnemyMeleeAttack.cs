using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    private PlayerManager playerManager;
    private LevelManager levelManager;
    private PlayerInRoom[] spawnedRooms;
    private GameObject portal;
    private bool getRooms;
 
    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        StartCoroutine(DestroyTimer());

    }
    private void Update()
    {
        if (portal == null)
        {
            portal = GameObject.FindGameObjectWithTag("Portal");
        }
        if (portal != null && !getRooms)
        {
            spawnedRooms = GameObject.FindObjectsOfType<PlayerInRoom>();
            getRooms = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerManager>().SetHealth(-20, EnemyWeaponType.MELEE);
            if (spawnedRooms != null)
            {
                foreach (PlayerInRoom script in spawnedRooms)
                {
                    if(script.GetIsPlayerInRoom())
                    {
                        script.PlayerMeleeHitsTaken(1);
                    }
                }
            }
            Destroy(this.gameObject);
        }
    }
    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
