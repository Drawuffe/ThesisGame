using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
public class BurrowMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{

    public bool canClick = false;
    public bool moving = false;
    public RectTransform rectTransform;
    public Transform parentTransform;
    public Image image;
    bool isRotating = false;
    float duration = 0.3f;
    private Color originalColor;
    private int selectedIndex;
    private AudioController audioController;
    




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalColor = image.color;
        audioController = GetComponent<AudioController>();
        

    }

    // Update is called once per frame
    public void OnBeginDrag(PointerEventData eventData)
    {

        GameManager.Instance.pieceButtons.SetActive(false); 
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
        AudioController audioController = GetComponent<AudioController>();
        audioController.PlayAudio(2);
    }

 
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.pieceButtons.SetActive(false);


        if(!moving)
        {
            TriggerRotation();
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            
            BurrowInfo pieceInfo = GetComponent<BurrowInfo>();
            if(pieceInfo.burrowName == "Corner")
            {
                GameManager.Instance.cornerPieces += 1;
                ClearBurrowColliders(transform);
                Destroy(this.gameObject); 
                GameManager.Instance.UpdateBurrowButton();
                GameManager.Instance.addedBurrowList.RemoveAt(pieceInfo.burrowIndex);


            }
            if(pieceInfo.burrowName == "Straight")
            {
                GameManager.Instance.straightPieces += 1;
                ClearBurrowColliders(transform);
                Destroy(this.gameObject); 
                GameManager.Instance.UpdateBurrowButton();
                GameManager.Instance.addedBurrowList.RemoveAt(pieceInfo.burrowIndex);

                
            }
            if(pieceInfo.burrowName == "Three")
            {
                GameManager.Instance.threePieces += 1;
                ClearBurrowColliders(transform);
                Destroy(this.gameObject); 
                GameManager.Instance.UpdateBurrowButton();
                GameManager.Instance.addedBurrowList.RemoveAt(pieceInfo.burrowIndex);
                
                
                
            }
            if(pieceInfo.burrowName == "Four")
            {
                GameManager.Instance.fourPieces += 1;
                ClearBurrowColliders(transform);
                Destroy(this.gameObject); 
                GameManager.Instance.UpdateBurrowButton();
                GameManager.Instance.addedBurrowList.RemoveAt(pieceInfo.burrowIndex);
                
    
                
            }
        }

        
    }

    public void TriggerRotation()
    {

        if (!isRotating)
        {
            StartCoroutine(RotateRoutine(-90f));
            audioController.PlayAudio(3);
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

    public void ClearBurrowColliders(Transform currentTransform)
    {

        for (int i = currentTransform.childCount - 1; i >= 0; i--)
        {
            GameManager.Instance.allColliders.Remove(currentTransform.GetChild(i).gameObject);
            Destroy(currentTransform.GetChild(i).gameObject);
        }
    }

    

  

}
