using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public List<Rooms> topRooms;
    public List<Rooms> rightRooms;
    public List<Rooms> bottomRooms;
    public List<Rooms> leftRooms;

    public GameObject closedRoom;
    public List<GameObject> spawnedRooms;
    public float spawnTimer;

    public GameObject exitPortal;
    private bool spawnedPortal = false;

    private void FixedUpdate()
    {
        if(spawnTimer <= 0 && !spawnedPortal)
        {
            Instantiate(exitPortal, spawnedRooms[spawnedRooms.Count - 1].transform.position, Quaternion.identity);
            spawnedPortal = true;
        }
        else if(!spawnedPortal)
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
