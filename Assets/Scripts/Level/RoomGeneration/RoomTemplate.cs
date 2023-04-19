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
    private int numOfRooms;
    private int maxNumOfRooms = 13;

    private void Start()
    {
        numOfRooms++;
    }
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

    public void AddNumOfRooms(int numberOfRoomsAdded)
    {
        numOfRooms += numberOfRoomsAdded;
    }
    public int GetNumOfRooms()
    {
        return numOfRooms;
    }
    public int GetMaxNumOfRooms()
    {
        return maxNumOfRooms;
    }
}
