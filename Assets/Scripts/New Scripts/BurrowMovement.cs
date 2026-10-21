using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
public class BurrowMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{

    public bool canClick = false;
    public bool moving = false;
    public RectTransform rectTransform;
    private BlueprintInfo blueprintInfoUI;
    private Blueprint blueprintInfo;
    private RectTransform parent; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        blueprintInfoUI = GameObject.FindWithTag("BlueprintMenu").GetComponent<BlueprintInfo>();

        parent = GameObject.FindWithTag("Droppable").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    public void OnBeginDrag(PointerEventData eventData)
    {

        
    
        
        
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


        if(CompareTag == "Corner")
        {
            if(Instance.GameManager.cornerPieces > 0)
            {
                canClick = true;
                Debug.Log("can click");
                Instance.GameManager.cornerPieces -= 1;
                blueprintInfo = GetComponent<Blueprint>();
                blueprintInfo.AssignValues();

            }
            else
            {
                canClick = false;
                Debug.Log("can't click");
            }
        }
        
        
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
