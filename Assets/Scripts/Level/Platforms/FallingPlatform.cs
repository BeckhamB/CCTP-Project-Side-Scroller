using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script implements the falling movement of the falling platform
public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 1f;
    private float destroyTimer = 2f;
    [SerializeField] private Rigidbody2D rb;
    private PlatformRespawn platformRespawn;
    // Start is called before the first frame update
    void Start()
    {
        platformRespawn = GetComponentInParent<PlatformRespawn>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Falling());
        }
    }
    private IEnumerator Falling()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        platformRespawn.StartRespawnTimer();
        Destroy(gameObject, destroyTimer);
        
    }
}
