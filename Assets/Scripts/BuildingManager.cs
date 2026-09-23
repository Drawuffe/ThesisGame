using UnityEngine;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour
{

    //BLUEPRINTS
    //list of all he available blueprints
    //total in of total number of blueprints
    //Blueprint inventory panel to trigger on and off
    //Blueprint content to fill when blueprint is collected

    //TENANT
    //list of all he available tenants
    //total in of total number of tenants
    //Tenant inventory panel to trigger on and off
    //Tenant content to fill when worker is collected

    //SYSTEMS
    //When file tab is clicked, correct inventory is visable
    //When item is clicked and dragged, it is removed from the inventory and placed in the scene
    //When item is removed from inventory, buttons appear around item if a blueprint to indicate its movement, 
    //When the player clicks the "X", the item should return to the players inventory
    //When the player is placing a blueprint, it can only be "Checked" in place when it matches with the surrounding tunnels
    //When a blueprint or tenant is dragged off of the inventory they inventory should disappear until the item is either placed or canceled
    

    [SerializeField] List<ScriptableObject> scriptableObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
