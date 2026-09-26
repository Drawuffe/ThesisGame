using UnityEngine;

public class BluePrintButtons : MonoBehaviour
{
    //private Blueprint blueprintInfo;
    //private BlueprintPrefab blueprintPrefab;
    public DragAndDrop drag;
    public bool isActive;
    public bool placed = false;
    public bool clicking = false;
    public BlueprintInfo blueprintInfoVisabiliy;
    public Inventory inventoryVisable;

    private void Start()
    {

        this.gameObject.SetActive(false);

        
    }

    public void ButtonVisable()
    {
        if (isActive == false)
        {
            this.gameObject.SetActive(true);
            Debug.Log("buttons on");
            this.gameObject.SetActive(true);
            isActive = true;
        }
        else
        {   this.gameObject.SetActive(false);
            Debug.Log("buttons off");
            this.gameObject.SetActive(false);
            isActive = false;
        }
        
 
        
    }
    
    public void RotateBlueprint()
    {
        isActive = true;
        ButtonVisable();


        isActive = false;
        ButtonVisable();
        //when button is clicked the bluprint will rotate with the mouse
    }

    public void PlaceBlueprint()
    {
        ButtonVisable();
        drag = GetComponentInParent<DragAndDrop>();
        inventoryVisable = drag.inventory;
        inventoryVisable.InventoryVisable();
        drag.moving = false;
        drag.canClick = false;
        placed = true;
        MenuDisplaying();
        Blueprint blueprint = GetComponentInParent<Blueprint>();
        BuildingManager.Instance.MoneyDecrease(blueprint._cost);
        blueprintInfoVisabiliy.MenuVisable();
    }

    public void CancelPlacement()
    {
        isActive = true;
        ButtonVisable();
        inventoryVisable = drag.inventory;
        inventoryVisable.InventoryVisable();
        drag.moving = false;
        MenuDisplaying();
        Blueprint blueprint = GetComponentInParent<Blueprint>();
        blueprint.Reparent();
    

    
        //Blueprint returns to inventory and remains highlighted
    }

    public void MenuDisplaying()
    {
        blueprintInfoVisabiliy = BuildingManager.Instance.blueprintInfo;

        if (clicking == true)
        {
            blueprintInfoVisabiliy.MenuNotVisable();
            clicking = false;
        }
        else
        {
            blueprintInfoVisabiliy.MenuVisable();
            clicking = true;
        }
        //info for the blueprint is displayed when the button is held down
    }
}
