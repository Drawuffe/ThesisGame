using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Blueprint : MonoBehaviour
{
    //get a random blue print and save it as a variable for inventory to access

    public Blueprints[] blueprints;
    private string itemName;
    private Sprite sprite;
    private int cost;


    private void RandomizeBlueprint() 
    {
        int randomNumber = Random.Range(0, blueprints.Length);
        Blueprints randomBlueprint  = blueprints[randomNumber];
        print(randomBlueprint);

        itemName = randomBlueprint.itemName;
        sprite = randomBlueprint.image;
        cost = randomBlueprint.cost;

        //Debug.Log("itemName =" + itemName + "sprite" + sprite + "cost" + cost);

        BuildingManager.Instance.AddBlueprint(itemName,  sprite, cost);

    }

   

    
    
}
