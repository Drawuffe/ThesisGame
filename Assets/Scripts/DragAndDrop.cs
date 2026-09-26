using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{

    private RectTransform rectTransform;
    private Blueprint blueprintInfo;
    private RectTransform parent; 
    private BlueprintInfo blueprintInfoUI;
    public Inventory inventory;
    public BluePrintButtons buttons;
    public bool canClick = false;
    public bool moving = false;
    //private Image image;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        parent = GameObject.FindWithTag("Droppable").GetComponent<RectTransform>();
        blueprintInfoUI = GameObject.FindWithTag("BlueprintMenu").GetComponent<BlueprintInfo>();
        inventory = GameObject.Find("BluePrint_Content").GetComponent<Inventory>();
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (blueprintInfo._cost <= BuildingManager.Instance.money && buttons.placed == false)
        {
            
            canClick = true;
            RectTransform blueprintSelectedTrans = GetComponent<RectTransform>();
            ChangeParent(blueprintSelectedTrans);
            buttons = buttons.GetComponent<BluePrintButtons>();
            if(buttons.isActive == false)
            {
                buttons.ButtonVisable();
                blueprintInfoUI.MenuNotVisable();
                inventory.InventoryNoVisable();
            }
            
        }
        else
        {
            canClick = false;
        }
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canClick)
        {

            rectTransform.anchoredPosition += eventData.delta;
        

        }
        else
        {
            print("can't click");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("item dropped");
    }

 
    public void OnPointerDown(PointerEventData eventData)
    {
        blueprintInfo = GetComponent<Blueprint>();
        blueprintInfo.AssignValues();
    }

    public void ChangeParent(RectTransform blueprint)
    {
        Vector3 worldPos = blueprint.position;
        Vector2 worldSize = blueprint.rect.size;
        Vector3 worldScale = blueprint.lossyScale;
        

        blueprint.SetParent(parent, worldPositionStays: true);

        Vector2 newSize = new Vector2(worldSize.x / worldScale.x, worldSize.y / worldScale.y);

        blueprint.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newSize.x);
        blueprint.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newSize.x);

        blueprint.position = worldPos;
    }

}
