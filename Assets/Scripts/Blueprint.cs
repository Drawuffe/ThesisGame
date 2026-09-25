using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Blueprint : MonoBehaviour
{
    //get a random blue print and save it as a variable for inventory to access

   
    public string _name;
    public Sprite _sprite;
    public int _cost;
    private BlueprintInfo blueprintInfoUI;
    
    private void Start()
    {
        blueprintInfoUI = GameObject.FindWithTag("BlueprintMenu").GetComponent<BlueprintInfo>();
    }

    public void StoreBlueprintInfo(string itemName, int itemCost, Sprite itemSprite)
    {
        _name = itemName;
        _cost = itemCost;
        _sprite = itemSprite;
    }

    public void AssignValues()
    {
        blueprintInfoUI.ChangeDisplay(_cost, _sprite);
    }

   

    
    
}
