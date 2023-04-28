using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawns the idle platforms for the spawn room on startup
public class SpawnRoom : MonoBehaviour
{
    private GameObject roomTemplate;
    public GameObject platformPrefab;
    private AddPlatforms[] addPlatforms;
    private PlayerInRoom playerInRoom;
    // Start is called before the first frame update
    void Start()
    {
        playerInRoom = GetComponent<PlayerInRoom>();
        GameObject platform = Instantiate(platformPrefab, transform.position, Quaternion.identity);
        addPlatforms = gameObject.GetComponentsInChildren<AddPlatforms>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
