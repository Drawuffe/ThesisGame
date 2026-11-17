using UnityEngine;

public class RoomAddons : MonoBehaviour
{
    public string roomName;
    private Sprite roomSprite;
  
  

    
    public void StoreInfo(string burrowName, Sprite burrowSprite)
    {
        roomName = burrowName;
        roomSprite = burrowSprite;
        
    }
}
