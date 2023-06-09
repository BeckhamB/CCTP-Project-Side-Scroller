using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script handles the instantiated attack prefab from the enemy and passes information
//to the level manager and room manager
public class EnemyRangedAttack : MonoBehaviour
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
        if(collision.CompareTag("Player"))
        {
            //increments the room manager values for the current room the enemy is in
            collision.GetComponent<PlayerManager>().SetHealth(-20, EnemyWeaponType.RANGED);
            if (spawnedRooms != null)
            {
                foreach (PlayerInRoom script in spawnedRooms)
                {
                    if (script.GetIsPlayerInRoom())
                    {
                        script.PlayerRangedHitsTaken(1);
                    }
                }
            }
            Destroy(this.gameObject);
        }
    }
    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
