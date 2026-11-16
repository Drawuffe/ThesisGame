using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
public class BurrowMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
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
    private float elapsedTime = 0f;
    private float holdTime = .3f;
    private bool isHolding = false;
    




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalColor = image.color;
        

    }
    void Update()
    {
        if(isHolding == true)
        {
            elapsedTime += Time.deltaTime;
        }

        if(elapsedTime >= holdTime && moving == false)
        {
            GameManager.Instance.roomPieceButtons.SetActive(true);
            GameManager.Instance.roomPieceButtons.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        GameManager.Instance.pieceButtons.SetActive(false); 
        GameManager.Instance.roomPieceButtons.SetActive(false);
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
        GameManager.Instance.audioController.PlayAudio(2);
        GameManager.Instance.CheckForCompletion();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.instantiateParent = rectTransform.parent;
        GameManager.Instance.pieceButtons.SetActive(false);
        GameManager.Instance.roomPieceButtons.SetActive(false);
        isHolding = true;
        

  
    }
    public void OnPointerUp(PointerEventData eventData)
    {

        isHolding = false;
        

        if(elapsedTime <= holdTime && !moving)
        {
            TriggerRotation();
            elapsedTime = 0;
        }
        else
        {

            elapsedTime = 0;
            
            
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        GameManager.Instance.pieceButtons.SetActive(false);
        
        
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //removes the piece and resets all its values.
            BurrowInfo pieceInfo = GetComponent<BurrowInfo>();
            if(pieceInfo.burrowName == "Corner")
            {
                
                GameManager.Instance.cornerPieces += 1;
                ClearBurrowColliders(transform);
                GameManager.Instance.UpdateBurrowButton();
                Destroy(this.gameObject); 
                Debug.Log(pieceInfo.burrowIndex);
                pieceInfo.burrowIndex = GameManager.Instance.addedBurrowList.IndexOf(this.gameObject);
                GameManager.Instance.addedBurrowList.RemoveAt(pieceInfo.burrowIndex);
               
                


            }
            if(pieceInfo.burrowName == "Straight")
            {
                
                GameManager.Instance.straightPieces += 1;
                ClearBurrowColliders(transform);
                Destroy(this.gameObject); 
                GameManager.Instance.UpdateBurrowButton();
                pieceInfo.burrowIndex = GameManager.Instance.addedBurrowList.IndexOf(this.gameObject);
                GameManager.Instance.addedBurrowList.RemoveAt(pieceInfo.burrowIndex);

                
            }
            if(pieceInfo.burrowName == "Three")
            {
                
                GameManager.Instance.threePieces += 1;
                ClearBurrowColliders(transform);
                Destroy(this.gameObject); 
                GameManager.Instance.UpdateBurrowButton();
                pieceInfo.burrowIndex = GameManager.Instance.addedBurrowList.IndexOf(this.gameObject);
                GameManager.Instance.addedBurrowList.RemoveAt(pieceInfo.burrowIndex);
                
                
                
            }
            if(pieceInfo.burrowName == "Four")
            {
                GameManager.Instance.fourPieces += 1;
                ClearBurrowColliders(transform);
                Destroy(this.gameObject); 
                GameManager.Instance.UpdateBurrowButton();
                pieceInfo.burrowIndex = GameManager.Instance.addedBurrowList.IndexOf(this.gameObject);
                GameManager.Instance.addedBurrowList.RemoveAt(pieceInfo.burrowIndex);
                
    
                
            }
            
            GameManager.Instance.CheckForCompletion();
        }

        
    }

    public void TriggerRotation()
    {

        if (!isRotating)
        {
            StartCoroutine(RotateRoutine(-90f));
            GameManager.Instance.audioController.PlayAudio(3);
            GameManager.Instance.CleanList(GameManager.Instance.allColliders);
            
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
        GameManager.Instance.CheckForCompletion();
        isRotating = false;
        
    }

    public void ClearBurrowColliders(Transform currentTransform)
    {
        //Clears the list of burrow coliders when an object is removed so they don't remain in the list
        for (int i = currentTransform.childCount - 1; i >= 0; i--)
        {
            GameManager.Instance.allColliders.Remove(currentTransform.GetChild(i).gameObject);
            Destroy(currentTransform.GetChild(i).gameObject);
        }
    }

    

  

}
