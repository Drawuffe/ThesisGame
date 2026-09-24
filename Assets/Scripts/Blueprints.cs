using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Blueprints", menuName = "Scriptable Objects/Blueprints")]
public class Blueprints : ScriptableObject
{


    public Sprite image;
    public string itemName;
    public int cost;
    public int workersNeeded;
    public bool collected = false;

    

}
