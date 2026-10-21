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
    private bool pieceSpawned = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    public void OnBeginDrag(PointerEventData eventData)
    {

        
        moving = true;
        
        
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
        moving = false;
    }

 
    public void OnPointerDown(PointerEventData eventData)
    {

        //Checks if the gameobject being clicked is a corner or another piece
        if(gameObject.tag == "Corner") //0
        {
            if(GameManager.Instance.cornerPieces > 0)
            {
                canClick = true;
                Debug.Log("can click, instantiate corner piece");
                GameManager.Instance.cornerPieces -= 1;
                GameManager.Instance.pieceClicked = 0;
                pieceSpawned = true;
                

            }
            else
            {
                canClick = false;
                Debug.Log("can't click");
            }
        }

        if (pieceSpawned == true)
        {

            pieceSpawned = false;
            GameManager.Instance.parentTransform = rectTransform;
            GameManager.Instance.BurrowPieceFound();
        }
        else
        {
            Debug.Log("No piece spawned");
        }
        
        
    }

    

  

}
