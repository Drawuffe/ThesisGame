using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{

    public GameObject blueprintPrefab;
    public RectTransform parentTransform;
    public RectTransform buidlingCanvas;
    public RectTransform screenParent;
    private Draggable drag;
    


    public void CreateBlueprint(Sprite sprite)
    {
        drag = blueprintPrefab.GetComponent<Draggable>();
        print(sprite);
        GameObject newChild = Instantiate(blueprintPrefab);
        Image image = newChild.GetComponent<Image>();
        newChild.transform.SetParent(parentTransform, true);
        drag.canvas = buidlingCanvas;
        drag.parent = screenParent;
        image.sprite = sprite;
    }
}
