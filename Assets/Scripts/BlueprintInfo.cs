using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BlueprintInfo : MonoBehaviour
{
    public Image imageUI;
    public TextMeshProUGUI costUI;

    public void ChangeDisplay(int cost, Sprite sprite)
    {
        costUI.text = cost.ToString();
        imageUI.sprite = sprite;
    }

   
}
