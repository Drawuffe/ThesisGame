using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{

    private RectTransform rectTransform;
    private Blueprints blueprintSO;
    private RectTransform parent; 
    //private Image image;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        parent = GameObject.FindWithTag("Droppable").GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        
        
        RectTransform blueprintSelectedTrans = GetComponent<RectTransform>();
        ChangeParent(blueprintSelectedTrans);
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("item dropped");
    }

 
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("item clicked");
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
