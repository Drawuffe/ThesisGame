using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotateScript : MonoBehaviour, IPointerDownHandler
{
    public int clicks = 0;
    public BlueprintInfo blueprintInfoUI;
    public RectTransform rectTransform;
    public BluePrintButtons buttons;
    public Inventory inventory;


    void Start()
    {
        inventory = GameObject.Find("BluePrint_Content").GetComponent<Inventory>();
        blueprintInfoUI = GameObject.FindWithTag("BlueprintMenu").GetComponent<BlueprintInfo>();
    }

    public void Update()
    {
        if(buttons != null)
        {
            if(buttons.rotating == true)
            {
                Vector2 mousePos = Input.mousePosition;
                Vector2 objectPos = RectTransformUtility.WorldToScreenPoint(Camera.main, rectTransform.position);

        
                Vector2 direction = mousePos - objectPos;

        
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }

            if(clicks == 1)
            {
                clicks = clicks + 1;
            }
        }

       
        
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (clicks == 2)
        {
            buttons.RotateBlueprint();
        }
    }

    public void RotateInfo(BluePrintButtons _buttons)
    {
        //rectTransform = _rectTransform;
        buttons = _buttons;

    }
}
