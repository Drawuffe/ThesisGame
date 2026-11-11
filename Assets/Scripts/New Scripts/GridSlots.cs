using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GridSlots : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler, IPointerDownHandler
{

    public Image highlightOverlay;
    [SerializeField] private Color validColor = new Color(0, 1, 0, 0.3f); // Green
    [SerializeField] private Color invalidColor = new Color(1, 0, 0, 0.3f); // Red
    public bool hasChild;
    private BurrowMovement burrowScript;
    private CharacterMovement characterScript;

   


    void Start()
    {   
        hasChild = transform.Find("BurrowHole") != null;
       // burrowHomes = transform.Find("BurrowHole").GetComponent<GameObject>();
        if(transform.Find("BurrowHole"))
        {
            GameManager.Instance.burrowHomes.Add(this.gameObject);
        }

        if (highlightOverlay != null)
        {
            highlightOverlay.gameObject.SetActive(false);
        }
            
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(transform.childCount == 1 && GameManager.Instance.characterMoving == false)
        {
            highlightOverlay.gameObject.SetActive(true);
            highlightOverlay.color = validColor;
        }
        else
        {
            highlightOverlay.gameObject.SetActive(false);
        }

        
        // Check if the user is currently dragging an item
        if (eventData.pointerDrag != null)
        {
            burrowScript  = eventData.pointerDrag.GetComponent<BurrowMovement>();
            characterScript = eventData.pointerDrag.GetComponent<CharacterMovement>();
            
            if (burrowScript != null)
            {

                // Ask your inventory logic if this specific item can fit here
                if (transform.childCount == 1)
                {
                    highlightOverlay.gameObject.SetActive(true);
                    highlightOverlay.color = validColor;
                }
            
                if(transform.childCount == 2)
                {
                    highlightOverlay.gameObject.SetActive(false);
                    highlightOverlay.color = validColor;
    
                }
                else
                {
                    highlightOverlay.gameObject.SetActive(true);
                    highlightOverlay.color = invalidColor;
                }
            }
            if (characterScript!= null)
            {
                //change the highlight overlay here
            }
        }

    }
        
    public void OnDrop(PointerEventData eventData)
    {
        
        if(transform.childCount == 1 && GameManager.Instance.characterMoving == false)
        {
            //GameObject dropped = eventData.pointerDrag;
            burrowScript.parentTransform = transform;
        }
        if(transform.childCount == 2 && GameManager.Instance.characterMoving == true && transform.Find("BurrowHole"))
        {
            characterScript.characterParentTransform = transform;
            characterScript.characterPlaced = true;
        }
        else
        {
            characterScript.characterPlaced = false;
        }
        
        if (highlightOverlay != null)
        {
            highlightOverlay.gameObject.SetActive(false);
            highlightOverlay.color = validColor;
        }

        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (highlightOverlay != null)
        {
            highlightOverlay.gameObject.SetActive(false);
            highlightOverlay.color = validColor;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //when a grid spot is clicked on and is not taken already, then the player can click and 
        //view the menu of pieces to place.
        GameManager.Instance.instantiateParent = transform;
        if(transform.childCount == 1)
        {
            GameManager.Instance.pieceButtons.SetActive(true);
            GameManager.Instance.pieceButtons.transform.position = transform.position;

        }
        else
        {
            GameManager.Instance.pieceButtons.SetActive(false);
        }

    }
  

}
