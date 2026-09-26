using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BlueprintInfo : MonoBehaviour
{
    public Image imageUI;
    public TextMeshProUGUI costUI;
    public TextMeshProUGUI moneyUI;

    public void ChangeDisplay(int cost, Sprite sprite)
    {
        costUI.text = cost.ToString();
        imageUI.sprite = sprite;
    }

    public void MoneyDisplay(int totalMoney)
    {
        moneyUI.text = totalMoney.ToString();
    }

    public void MenuVisable()
    {
        this.gameObject.SetActive(true);
    }

    public void MenuNotVisable()
    {
        this.gameObject.SetActive(false);
    }

   
}
