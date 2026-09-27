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
    public bool _collected;
    private BlueprintInfo blueprintInfoUI;
    
    private void Start()
    {
        blueprintInfoUI = GameObject.FindWithTag("BlueprintMenu").GetComponent<BlueprintInfo>();
    }

    public void StoreBlueprintInfo(string itemName, int itemCost, Sprite itemSprite, bool itemCollection, bool itemPlacement)
    {
        _name = itemName;
        _cost = itemCost;
        _sprite = itemSprite;
        _collected =  itemCollection;

    }

    public void AssignValues()
    {
        blueprintInfoUI.ChangeDisplay(_cost, _sprite);
    }

    public void Reparent()
    {
        Inventory inventoryVisable = GameObject.Find("BluePrint_Content").GetComponent<Inventory>();
        this.gameObject.transform.SetParent(inventoryVisable.parentTransform, true);
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

    }

   

    
    
}
