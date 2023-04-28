using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a scriptable object used to adjust rooms values at runtime
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
