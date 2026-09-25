using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{

    public GameObject blueprintPrefab;
    public RectTransform parentTransform;
    public RectTransform buidlingCanvas;
    public RectTransform screenParent;

    


    public void CreateBlueprint(string name, int cost, Sprite sprite)
    {
        GameObject newChild = Instantiate(blueprintPrefab);
        Image image = newChild.GetComponent<Image>();
        newChild.transform.SetParent(parentTransform, true);
        image.sprite = sprite;
        Blueprint blueprintInfo = newChild.GetComponent<Blueprint>();
        if (blueprintInfo != null)
        {
            blueprintInfo.StoreBlueprintInfo(name, cost, sprite);
        }
        
    }

    
}
