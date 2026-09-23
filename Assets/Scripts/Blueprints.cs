using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Blueprints", menuName = "Scriptable Objects/Blueprints")]
public class Blueprints : ScriptableObject
{


    public Sprite image;
    public string description;
    public int cost;
    public int workersNeeded;
    public bool collected = false;

    //[SerializeField] List<ScriptableObject> myScripts;

    //public void AddScript(ScriptableObject script)
    //{
    //    if(collected)
    //    {
    //        myScripts.Add(script);
    //    }
    //}

}
