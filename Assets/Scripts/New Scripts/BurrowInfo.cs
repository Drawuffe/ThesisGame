using UnityEngine;
using System.Collections.Generic;

public class BurrowInfo : MonoBehaviour
{
    public string burrowName;
    public Sprite burrowSprite;
    public int burrowIndex;
    public List<GameObject> colliders = new List<GameObject>();

    //Holds the info from the scriptable object after the object is instantiated so it is accessable at anytime.
    public void StoreInfo(string burrowName_, Sprite burrowImage, int burrowIndex_)
    {
        burrowName = burrowName_;
        burrowSprite = burrowImage;
        burrowIndex = burrowIndex_;

    }

    public void AssignColliders(List<GameObject> colliderList)
    {
        colliders = colliderList;
    }

    
}
