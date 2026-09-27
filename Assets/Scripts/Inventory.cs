using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{

    public GameObject blueprintPrefab;
    public RectTransform parentTransform;
    public RectTransform buidlingCanvas;
    public RectTransform screenParent;
    public GameObject buildInventory;
    public BluePrintButtons buttons;
    public GameObject newChild;

    


    public void CreateBlueprint(string name, int cost, Sprite sprite, bool collected, bool placed)
    {
        newChild = Instantiate(blueprintPrefab);
        Image image = newChild.GetComponent<Image>();
        newChild.transform.SetParent(parentTransform, true);
        image.sprite = sprite;
        Blueprint blueprintInfo = newChild.GetComponent<Blueprint>();
        buttons = newChild.GetComponentInChildren<BluePrintButtons>();
        if (blueprintInfo != null)
        {
            collected = true;
            blueprintInfo.StoreBlueprintInfo(name, cost, sprite, collected, placed);
        }
        
    }

    public void InventoryVisable()
    {
        buildInventory.SetActive(true);
    }

    public void InventoryNoVisable()
    {
        buildInventory.SetActive(false);
    }

    
}
