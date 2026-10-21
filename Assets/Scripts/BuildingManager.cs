using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour
{



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
        //selectedCost = randomBlueprint.cost;
        //selectedCollected = randomBlueprint.collected;
        //selectedPlaced = randomBlueprint.placed;
        



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
