using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Rooms : ScriptableObject
{
    public GameObject room;
    public string roomName;
    public int weight;

    public Rooms(string roomName, int weight)
    {
        this.roomName = roomName;
        this.weight = weight;
    }
}
