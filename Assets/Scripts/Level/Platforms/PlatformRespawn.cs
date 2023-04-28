using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script respawns the falling platform at its original position
public class PlatformRespawn : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    private float respawnTimer = 2f;


    public void StartRespawnTimer()
    {
        StartCoroutine(RespawnCoroutine());
    }
    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnTimer);
        GameObject platformInstance = Instantiate(platformPrefab, this.gameObject.transform.position, Quaternion.identity);
        platformInstance.transform.parent = this.transform;
    }
}
