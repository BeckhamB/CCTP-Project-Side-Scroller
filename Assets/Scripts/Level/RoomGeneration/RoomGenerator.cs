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

    private void Start()
    {
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
                int randomNumber = Random.Range(1, 101);
                List<Rooms> possibleRooms = new List<Rooms>();
                foreach (Rooms room in roomTemplate.bottomRooms)
                {
                    if(randomNumber <= room.weight)
                    {
                        possibleRooms.Add(room);
                    }  
                }
                if (possibleRooms.Count > 0)
                {
                    GameObject selectedRoom = possibleRooms[Random.Range(0, possibleRooms.Count)].room;
                    Instantiate(selectedRoom, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(roomTemplate.bottomRooms[1].room, transform.position, Quaternion.identity);
                }  
            }
            else if (doorDirection == 2)
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
                    Instantiate(selectedRoom, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(roomTemplate.leftRooms[1].room, transform.position, Quaternion.identity);
                }
            }
            else if (doorDirection == 3)
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
                    Instantiate(selectedRoom, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(roomTemplate.topRooms[1].room, transform.position, Quaternion.identity);
                }
            }
            else if (doorDirection == 4)
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
                    Instantiate(selectedRoom, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(roomTemplate.rightRooms[1].room, transform.position, Quaternion.identity);
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
}
