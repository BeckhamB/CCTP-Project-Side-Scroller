using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlatforms : MonoBehaviour
{
    public GameObject platformSpawner;

    private void Start()
    {
        Instantiate(platformSpawner, transform.position, Quaternion.identity);
    }
}
