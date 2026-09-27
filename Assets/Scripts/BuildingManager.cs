using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
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
    

    //collect the random and tell the inventory what to instaniate

    public static BuildingManager Instance {  get; private set; }

    private Inventory inventory;
    public BlueprintInfo blueprintInfo;
    public string selectedName;
    public int selectedCost;
    public Sprite selectedSprite;
    public bool selectedCollected;
    public bool selectedPlaced;
    public Blueprints[] blueprints;
    public RectTransform objectSelected;
    public RotateScript rotateScript;
  

    public int money = 0;

    private void Awake()
    {
        if(Instance != null && Instance !=this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
  
    }

    void Start()
    {
        inventory = GameObject.Find("BluePrint_Content").GetComponent<Inventory>();
        blueprintInfo = GameObject.FindWithTag("BlueprintMenu").GetComponent<BlueprintInfo>();
        rotateScript = GameObject.FindWithTag("Droppable").GetComponent<RotateScript>();
        
    }

    public void RandomizeBlueprint() 
    {
        int randomNumber = Random.Range(0, blueprints.Length);
        Blueprints randomBlueprint  = blueprints[randomNumber];
        print(randomBlueprint);

        selectedName = randomBlueprint.name;
        selectedSprite = randomBlueprint.image;
        selectedCost = randomBlueprint.cost;
        selectedCollected = randomBlueprint.collected;
        selectedPlaced = randomBlueprint.placed;
        



        inventory.CreateBlueprint(selectedName, selectedCost, selectedSprite, selectedCollected, selectedPlaced);

    }


    public void MoneyIncrease(int amount)
    {
        money = money + amount;
        blueprintInfo.MoneyDisplay(money);

    }
    public void MoneyDecrease(int amount)
    {
        Debug.Log(amount);
        money = money - amount;
        blueprintInfo.MoneyDisplay(money);


    }
    public void SelectedObjectInfo()
    {
        rotateScript.rectTransform = objectSelected;
        rotateScript.buttons = objectSelected.GetComponentInChildren<BluePrintButtons>();

    }
}
