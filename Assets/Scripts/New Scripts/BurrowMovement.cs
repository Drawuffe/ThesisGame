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
    public Transform parentTransform;
    public Image image;
    bool isRotating = false;
    float duration = 0.3f;
    private Color originalColor;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalColor = image.color;
        

    }

    // Update is called once per frame
    public void OnBeginDrag(PointerEventData eventData)
    {

        
        moving = true;
        parentTransform = transform.parent;
        image.raycastTarget = false;
        image.color = Color.yellow;

        if(transform.parent.name is "Screen" )
        {
            
            parentTransform = transform.parent;
        }
        else
        {
            rectTransform.SetParent(rectTransform.root);
            rectTransform.SetAsLastSibling();
        }


        
    }

    public void OnDrag(PointerEventData eventData)
    {

        
        rectTransform.anchoredPosition += eventData.delta;

        if (canClick)
        {

            
        

        }
        else
        {
            print("can't click");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("item dropped");
        moving = false;
        transform.SetParent(parentTransform);
        image.raycastTarget = true;
        image.color= originalColor;
    }

 
    public void OnPointerDown(PointerEventData eventData)
    {

        if(!moving)
        {
            TriggerRotation();
        }
        
        
        
        
    }

    public void TriggerRotation()
    {

        if (!isRotating)
        {
            StartCoroutine(RotateRoutine(-90f));
        }
    }

    private IEnumerator RotateRoutine(float angle)
    {
        isRotating = true;

        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0, 0, angle);
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            // Smoothly lerp the rotation over time
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timePassed / duration);
            yield return null;
        }

        // Ensure it snaps perfectly to the final target angle
        transform.rotation = targetRotation; 
        isRotating = false;
    }

    

  

}
