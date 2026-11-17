using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class AnimalCollision : MonoBehaviour
{
    private CharacterStored characterStored;
    private AnimalManager animalManager;
    private HashSet<Collider> _occupants = new HashSet<Collider>();
    private List<Collider> _toRemove = new List<Collider>();

    public bool animalCollision, animalRoom, animalColRow, animalSmell;
    void Start()
    {
        characterStored = GetComponentInParent<CharacterStored>();
        animalManager = GetComponentInParent<AnimalManager>();
        

    }
    private void FixedUpdate()
    {
        _toRemove.Clear();

        foreach (Collider col in _occupants)
        {
            
            if (col == null || !col.enabled || !col.gameObject.activeInHierarchy)
            {
                _toRemove.Add(col);
            }
        }

        foreach (Collider col in _toRemove)
        {
            _occupants.Remove(col);
            HandleColliderLeft(col);
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Collider") || other.gameObject == this.gameObject)
        {
            return;
        }

        Transform grandparent = transform.parent.parent;
        if(grandparent.name == "Characters")
        {
            return;
        }

        if(other.transform.parent.parent.name == "Characters")
        {
            return;
        }
        
        else
        {
            if(characterStored.wantInfo_1!= "")
            {
                if(other.gameObject.GetComponentInParent<RoomAddons>())
                {
                    
                }
                else
                {
                    if(other.gameObject.GetComponentInParent<CharacterStored>().characterName == characterStored.animalCollsionName)
                    { 
                        animalCollision = true;
                        CheckRequirements();
                        
                    }
                }
                
                    
            }
            else
            {
                Debug.Log("Want1, not needed for this object");
                animalCollision = true;
                CheckRequirements();
                
            }


            if(characterStored.wantInfo_2!= "")
            {
                
                if(other.transform.parent.CompareTag("Room"))
                {
                    
                    if(gameObject.GetComponentInParent<CharacterStored>().animalRooms == "Pool" && other.GetComponentInParent<RoomAddons>().roomName == "Pool")
                    {
                        
                            
                        animalRoom = true;
                        CheckRequirements();
                        _occupants.Add(other);
                        

                    }
                    if(gameObject.GetComponentInParent<CharacterStored>().animalRooms == "Kitchen" && other.GetComponentInParent<RoomAddons>().roomName == "Kitchen")
                    {
                        
                            
                        animalRoom = true;
                        CheckRequirements();
                        _occupants.Add(other);
                        
                    }
                    if(gameObject.GetComponentInParent<CharacterStored>().animalRooms == "LivingRoom" && other.GetComponentInParent<RoomAddons>().roomName == "LivingRoom")
                    {

                        animalRoom = true;
                        CheckRequirements();
                        _occupants.Add(other);
   
                    }
                    if(gameObject.GetComponentInParent<CharacterStored>().animalRooms == "Garden" && other.GetComponentInParent<RoomAddons>().roomName == "Garden")
                    {

                        animalRoom = true;
                        CheckRequirements();
                        _occupants.Add(other);

                    }
                    
                    
                }


            }
            else
            {
                Debug.Log("Want2, not needed for this object");
                animalRoom = true;
                CheckRequirements();
                
            }

            if(characterStored.wantInfo_3!= "")
            {
                
            }
            else
            {
                Debug.Log("Want3, not needed for this object");
                animalColRow = true;
                CheckRequirements();
                
            }

            if(characterStored.wantInfo_4!= "")
            {
                if(gameObject.GetComponentInParent<CharacterStored>().animalSmells == true)
                {
                    //animal smells
                    //if(other animal being collided with with neighbor collider does not like smells then requirements not meet)
                    //else)requirements meet)
                }
                //want 4 animal smell requirements
            }
            else
            {
                animalSmell = true;
                CheckRequirements();
                
            }
                
        }
        
    }
    


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collider"))
        {
            return;
        }
        
        if(other.gameObject.GetComponentInParent<CharacterStored>()!=null)
        {
            if(other.gameObject.GetComponentInParent<CharacterStored>().animalCollsionName == characterStored.characterName)
            { 
                animalCollision = false;
                CheckRequirements();
                
            }
  
        }

        if (_occupants.Remove(other))
        {
            HandleColliderLeft(other);
        }
 

    }

    public void CheckRequirements()
    {
        
        if(animalCollision == true && animalColRow == true && animalRoom == true && animalSmell == true)
        {
            animalManager.requirmentsMeet = true;
            animalManager.ChangeAnimalSprite();
        }
        else
        {
            animalManager.requirmentsMeet = false;
            animalManager.ChangeAnimalSprite();
        }
    }
    private void HandleColliderLeft(Collider col)
    {
        animalRoom = false;
        CheckRequirements();
    }
}
