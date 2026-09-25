using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BlueprintInfo : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI cost;

    public void ChangeDisplay()
    {
        cost.text = BuildingManager.Instance.selectedCost.ToString();
        image.sprite = BuildingManager.Instance.selectedSprite;
    }
}
