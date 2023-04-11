using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplate temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        temp.spawnedRooms.Add(this.gameObject);
    }

}
