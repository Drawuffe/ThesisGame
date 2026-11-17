using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class RoomMovement : MonoBehaviour, IPointerClickHandler
{
   public void OnPointerClick(PointerEventData eventData)
    {
       
        GameManager.Instance.roomPieceButtons.SetActive(false);
      
        
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            
            //removes the piece and resets all its values.
            RoomAddons roomAddons = GetComponent<RoomAddons>();
            if(roomAddons.roomName == "Pool")
            {
                
                GameManager.Instance.startPool += 1;
                GameManager.Instance.poolText.text = GameManager.Instance.startPool.ToString();
                Destroy(this.gameObject); 
                



            }
            if(roomAddons.roomName == "Kitchen")
            {
                
                GameManager.Instance.startKitchen += 1;
                GameManager.Instance.kitchenText.text = GameManager.Instance.startKitchen.ToString();
                Destroy(this.gameObject); 
                
                

                
            }
            if(roomAddons.roomName == "LivingRoom")
            {
                
                GameManager.Instance.startLivingRoom += 1;
                GameManager.Instance.livingRoomText.text = GameManager.Instance.startLivingRoom.ToString();
                Destroy(this.gameObject); 
                
 
                
            }
            if(roomAddons.roomName == "Garden")
            {
                
                GameManager.Instance.startGarden += 1;
                GameManager.Instance.gardenText.text = GameManager.Instance.startGarden.ToString();
                Destroy(this.gameObject); 
                

                
            }


            
        }

        
    }
}
