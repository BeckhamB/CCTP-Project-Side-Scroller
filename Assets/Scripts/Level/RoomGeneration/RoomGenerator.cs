using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script instantiates the rooms dependant on the weighting values of their
//scriptable objects

//The original implementation is based off a tutorial by Blackthornprod (2018). Available here: https://www.youtube.com/watch?v=qAf9axsyijY
//However, this design has been thoroughly iterated upon to suit the needs of this project
public class RoomGenerator : MonoBehaviour
{
    public int doorDirection;

    public RoomTemplate roomTemplate;
    private int randomRoom;
    private bool isSpawned = false;
    public List<Rooms> roomList = new List<Rooms>();
    private LevelManager levelManager;


    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
        roomTemplate = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(0.1f);
        SpawnRooms();
    }
    private void SpawnRooms()
    {
        if(!isSpawned)
        {
            //If this is a northern node
            if (doorDirection == 1)
            {
                //Checks if the current number of rooms is close to the max
                if (roomTemplate.GetNumOfRooms() == (levelManager.TotalMaxNumOfRooms() - 2))
                {
                    //25% chance of closing the path by instantiating a room with only 1 opening
                    if (Random.Range(1, 101) <= 25)
                    {
                        roomTemplate.AddNumOfRooms(1);
                        Instantiate(roomTemplate.bottomRooms[0].room, transform.position, Quaternion.identity);
                    }
                    //Otherwise a random room from the possible rooms is selected appropriate to node opening direction Northern node = Southern door opening
                    else
                    {
                        SpawnBottomRooms();
                    }
                }
                //If the current number of rooms is even closer to the maximum then the chance of closing the path is higher
                else if (roomTemplate.GetNumOfRooms() == (levelManager.TotalMaxNumOfRooms() - 1))
                {
                    if (Random.Range(1, 101) <= 50)
                    {
                        roomTemplate.AddNumOfRooms(1);
                        Instantiate(roomTemplate.bottomRooms[0].room, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        SpawnBottomRooms();
                    }
                }
                // this is guaranteed once the maximum number is reached
                else if (roomTemplate.GetNumOfRooms() >= (levelManager.TotalMaxNumOfRooms()))
                {
                    roomTemplate.AddNumOfRooms(1);
                    Instantiate(roomTemplate.bottomRooms[0].room, transform.position, Quaternion.identity);
                }
                else
                {
                    SpawnBottomRooms();
                } 
            }
            //This is then repeated for the other 3 cardinal directions
            else if (doorDirection == 2)
            {
                if (roomTemplate.GetNumOfRooms() == (levelManager.TotalMaxNumOfRooms() - 2))
                {
                    if (Random.Range(1, 101) <= 25)
                    {
                        roomTemplate.AddNumOfRooms(1);
                        Instantiate(roomTemplate.leftRooms[0].room, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        SpawnLeftRooms();
                    }
                }
                else if (roomTemplate.GetNumOfRooms() == (levelManager.TotalMaxNumOfRooms() - 1))
                {
                    if (Random.Range(1, 101) <= 50)
                    {
                        roomTemplate.AddNumOfRooms(1);
                        Instantiate(roomTemplate.leftRooms[0].room, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        SpawnLeftRooms();
                    }
                }
                else if (roomTemplate.GetNumOfRooms() >= (levelManager.TotalMaxNumOfRooms()))
                {
                    roomTemplate.AddNumOfRooms(1);
                    Instantiate(roomTemplate.leftRooms[0].room, transform.position, Quaternion.identity);
                }
                else
                {
                    SpawnLeftRooms();
                }
            }
            else if (doorDirection == 3)
            {
                if (roomTemplate.GetNumOfRooms() == (levelManager.TotalMaxNumOfRooms() - 2))
                {
                    if (Random.Range(1, 101) <= 25)
                    {
                        roomTemplate.AddNumOfRooms(1);
                        Instantiate(roomTemplate.topRooms[0].room, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        SpawnTopRooms();
                    }
                }
                else if (roomTemplate.GetNumOfRooms() == (levelManager.TotalMaxNumOfRooms() - 1))
                {
                    if (Random.Range(1, 101) <= 50)
                    {
                        roomTemplate.AddNumOfRooms(1);
                        Instantiate(roomTemplate.topRooms[0].room, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        SpawnTopRooms();
                    }
                }
                else if (roomTemplate.GetNumOfRooms() >= (levelManager.TotalMaxNumOfRooms()))
                {
                    roomTemplate.AddNumOfRooms(1);
                    Instantiate(roomTemplate.topRooms[0].room, transform.position, Quaternion.identity);
                }
                else
                {
                    SpawnTopRooms();
                }
                
            }
            else if (doorDirection == 4)
            {
                if (roomTemplate.GetNumOfRooms() == (levelManager.TotalMaxNumOfRooms() - 2))
                {
                    if (Random.Range(1, 101) <= 25)
                    {
                        roomTemplate.AddNumOfRooms(1);
                        Instantiate(roomTemplate.rightRooms[0].room, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        SpawnRightRooms();
                    }
                }
                else if (roomTemplate.GetNumOfRooms() == (levelManager.TotalMaxNumOfRooms() - 1))
                {
                    if (Random.Range(1, 101) <= 50)
                    {
                        roomTemplate.AddNumOfRooms(1);
                        Instantiate(roomTemplate.rightRooms[0].room, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        SpawnRightRooms();
                    }
                }
                else if (roomTemplate.GetNumOfRooms() >= (levelManager.TotalMaxNumOfRooms()))
                {
                    roomTemplate.AddNumOfRooms(1);
                    Instantiate(roomTemplate.rightRooms[0].room, transform.position, Quaternion.identity);
                }
                else
                {
                    SpawnRightRooms();
                }
            }
            isSpawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            
            if(!collision.GetComponent<RoomGenerator>().isSpawned && !isSpawned)
            {
                Instantiate(roomTemplate.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            isSpawned = true;
        }
    }

    private void SpawnBottomRooms()
    {
        //random number generated between 1 and 100
        int randomNumber = Random.Range(1, 101);
        List<Rooms> possibleRooms = new List<Rooms>();
        //if the weight of the room is lower than the number it is added to the possible room array
        foreach (Rooms room in roomTemplate.bottomRooms)
        {
            if (randomNumber <= room.weight)
            {
                possibleRooms.Add(room);
            }
        }
        //a random room from the possible options is then spawned and the current number of rooms is updated
        if (possibleRooms.Count > 0)
        {
            GameObject selectedRoom = possibleRooms[Random.Range(0, possibleRooms.Count)].room;
            Instantiate(selectedRoom, transform.position, Quaternion.identity);
            roomTemplate.AddNumOfRooms(1);
        }
        //if the array is empty after this, a default room which doesnt increase or decrease a path is hcosen instead
        else
        {
            Instantiate(roomTemplate.bottomRooms[5].room, transform.position, Quaternion.identity);
            roomTemplate.AddNumOfRooms(1);
        }
    }

    //this function is repeated for the 3 other cardinal directions
    private void SpawnLeftRooms()
    {
        int randomNumber = Random.Range(1, 101);
        List<Rooms> possibleRooms = new List<Rooms>();
        foreach (Rooms room in roomTemplate.leftRooms)
        {
            if (randomNumber <= room.weight)
            {
                possibleRooms.Add(room);
            }
        }
        if (possibleRooms.Count > 0)
        {
            GameObject selectedRoom = possibleRooms[Random.Range(0, possibleRooms.Count)].room;
            roomTemplate.AddNumOfRooms(1);
            Instantiate(selectedRoom, transform.position, Quaternion.identity);

        }
        else
        {
            roomTemplate.AddNumOfRooms(1);
            Instantiate(roomTemplate.leftRooms[5].room, transform.position, Quaternion.identity);
        }
    }
    private void SpawnTopRooms()
    {
        int randomNumber = Random.Range(1, 101);
        List<Rooms> possibleRooms = new List<Rooms>();
        foreach (Rooms room in roomTemplate.topRooms)
        {
            if (randomNumber <= room.weight)
            {
                possibleRooms.Add(room);
            }
        }
        if (possibleRooms.Count > 0)
        {
            GameObject selectedRoom = possibleRooms[Random.Range(0, possibleRooms.Count)].room;
            roomTemplate.AddNumOfRooms(1);
            Instantiate(selectedRoom, transform.position, Quaternion.identity);
        }
        else
        {
            roomTemplate.AddNumOfRooms(1);
            Instantiate(roomTemplate.topRooms[5].room, transform.position, Quaternion.identity);
        }
    }
    private void SpawnRightRooms()
    {
        int randomNumber = Random.Range(1, 101);
        List<Rooms> possibleRooms = new List<Rooms>();
        foreach (Rooms room in roomTemplate.rightRooms)
        {
            if (randomNumber <= room.weight)
            {
                possibleRooms.Add(room);
            }
        }
        if (possibleRooms.Count > 0)
        {
            GameObject selectedRoom = possibleRooms[Random.Range(0, possibleRooms.Count)].room;
            roomTemplate.AddNumOfRooms(1);
            Instantiate(selectedRoom, transform.position, Quaternion.identity);
        }
        else
        {
            roomTemplate.AddNumOfRooms(1);
            Instantiate(roomTemplate.rightRooms[5].room, transform.position, Quaternion.identity);
        }
    }
}
