using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{

    public GameObject blueprintPrefab;
    public RectTransform parentTransform;
    public RectTransform buidlingCanvas;
    public RectTransform screenParent;
    private DragAndDrop drag;
    


    public void CreateBlueprint(Sprite sprite)
    {
        drag = blueprintPrefab.GetComponent<DragAndDrop>();
        print(sprite);
        GameObject newChild = Instantiate(blueprintPrefab);
        Image image = newChild.GetComponent<Image>();
        newChild.transform.SetParent(parentTransform, true);
        image.sprite = sprite;
    }
}
