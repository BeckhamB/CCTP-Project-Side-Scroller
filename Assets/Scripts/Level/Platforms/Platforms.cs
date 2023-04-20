using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Platforms : ScriptableObject
{
    public GameObject platform;
    public string platformName;
    public int weight;

    public Platforms(string platformName, int weight)
    {
        this.platformName = platformName;
        this.weight = weight;
    }
}
