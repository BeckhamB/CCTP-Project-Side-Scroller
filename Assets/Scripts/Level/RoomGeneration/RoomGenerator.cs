using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public int doorDirection;

    private RoomTemplate roomTemplate;
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
                randomRoom = Random.Range(0, roomTemplate.bottomRooms.Length);
                Instantiate(roomTemplate.bottomRooms[randomRoom], transform.position, Quaternion.identity);
            }
            else if (doorDirection == 2)
            {
                randomRoom = Random.Range(0, roomTemplate.leftRooms.Length);
                Instantiate(roomTemplate.leftRooms[randomRoom], transform.position, Quaternion.identity);
            }
            else if (doorDirection == 3)
            {
                randomRoom = Random.Range(0, roomTemplate.topRooms.Length);
                Instantiate(roomTemplate.topRooms[randomRoom], transform.position, Quaternion.identity);
            }
            else if (doorDirection == 4)
            {
                randomRoom = Random.Range(0, roomTemplate.rightRooms.Length);
                Instantiate(roomTemplate.rightRooms[randomRoom], transform.position, Quaternion.identity);
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
