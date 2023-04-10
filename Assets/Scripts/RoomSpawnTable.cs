using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomSpawnTable : ScriptableObject
{
    [SerializeField] private List<Rooms> rooms;
    [System.NonSerialized] private bool isInitialised = false;

    private float sumWeight;
    
    private void Initialise()
    {
        if(!isInitialised)
        {
            //foreach(List<Rooms> room in rooms)
            {
               // sumWeight += room.weight;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
