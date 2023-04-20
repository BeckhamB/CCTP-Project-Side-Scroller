using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (doorDirection == 1)
            {
                if (roomTemplate.GetNumOfRooms() == (levelManager.TotalMaxNumOfRooms() - 2))
                {
                    if (Random.Range(1, 101) <= 25)
                    {
                        roomTemplate.AddNumOfRooms(1);
                        Instantiate(roomTemplate.bottomRooms[0].room, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        SpawnBottomRooms();
                    }
                }
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
        int randomNumber = Random.Range(1, 101);
        List<Rooms> possibleRooms = new List<Rooms>();
        foreach (Rooms room in roomTemplate.bottomRooms)
        {
            if (randomNumber <= room.weight)
            {
                possibleRooms.Add(room);
            }
        }
        if (possibleRooms.Count > 0)
        {
            GameObject selectedRoom = possibleRooms[Random.Range(0, possibleRooms.Count)].room;
            Instantiate(selectedRoom, transform.position, Quaternion.identity);
            roomTemplate.AddNumOfRooms(1);
        }
        else
        {
            Instantiate(roomTemplate.bottomRooms[5].room, transform.position, Quaternion.identity);
            roomTemplate.AddNumOfRooms(1);
        }
    }
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
