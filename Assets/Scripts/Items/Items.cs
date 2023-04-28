using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a scriptable object used to adjust item values at runtime
[CreateAssetMenu]
public class Items : ScriptableObject
{
    public GameObject items;
    public string itemName;
    public int weight;

    public Items(string itemName, int weight)
    {
        this.itemName = itemName;
        this.weight = weight;
    }
}
