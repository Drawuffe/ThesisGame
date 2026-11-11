using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    private RectTransform rectTransform;
    public Transform characterParentTransform;
    private Image image;
    public bool characterPlaced = false;
    public Transform originalTransform;
    


    //when moving character the green highlighter effect for burrow placement is off
    //when character is not releaased on a burrow piece than snap it back to the parent
    //highlight the pieces that the character can be placed
    //when character is placed, have it be replaced with the new character sprite

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        originalTransform = transform.parent;
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {   
        GameManager.Instance.characterMoving = true;
        characterParentTransform = transform.parent;
        image.raycastTarget = false;
        rectTransform.SetParent(rectTransform.root);
        rectTransform.SetAsLastSibling();


    }

    public void OnDrag(PointerEventData eventData)
    {

        
        rectTransform.anchoredPosition += eventData.delta;

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GameManager.Instance.characterMoving = false;
        transform.SetParent(characterParentTransform);
        image.raycastTarget = true;
        GameManager.Instance.CheckForCompletion();
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            transform.SetParent(originalTransform);
        }
    }

    
}
