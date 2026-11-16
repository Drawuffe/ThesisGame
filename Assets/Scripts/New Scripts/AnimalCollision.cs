using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class AnimalCollision : MonoBehaviour
{
    private CharacterStored characterStored;
    private AnimalManager animalManager;

    public bool animalCollision, animalRoom, animalColRow, animalSmell;
    void Start()
    {
        characterStored = GetComponentInParent<CharacterStored>();
        animalManager = GetComponentInParent<AnimalManager>();
        

    }
    
    void Update()
    {
        CheckRequirements();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Collider") || other.gameObject == this.gameObject)
        {
            return;
        }

        Transform grandparent = transform.parent.parent;
        if(grandparent.name == "Characters")
        {
            //Debug.Log("Object has not been moved yet");
            //animalCollision = false;
            animalCollision = false;
            return;

        }
        if(other.transform.parent.parent.name == "Characters")
        {
            animalCollision = false;
            
            return;

        }
        else
        {
        
        
            if(characterStored.wantInfo_1!= "")
            {
                if (gameObject.CompareTag("Row") && other.gameObject.CompareTag("Row"))
                {
                    //Debug.Log("Rows colliding");
                    if(other.gameObject.GetComponentInParent<CharacterStored>().characterName == characterStored.animalCollsionName)
                    { 
                        animalCollision = true;
                       
                        
                        //Debug.Log(transform.parent + "meets the row requirements with"+ other.transform.parent);
                        
                    }
 
                    
            
                }
                else if (gameObject.CompareTag("Column") && other.gameObject.CompareTag("Column"))
                {
                    
                    
                    if(other.gameObject.GetComponentInParent<CharacterStored>().characterName == characterStored.animalCollsionName)
                    { 
                        animalCollision = true;
                        
                        //Debug.Log("animals colliding with the right column requirements");
                            
                    }


                    
                }
                else if (gameObject.CompareTag("Neighbor") && other.gameObject.CompareTag("Neighbor"))
                {
                    
                    
                    if(other.gameObject.GetComponentInParent<CharacterStored>().characterName == characterStored.animalCollsionName)
                    { 
                        animalCollision = true;
                        
                        //Debug.Log("animals colliding with the right neighbor requirements");
                        
                    }

            
                }
                
                
                    
            }
            else
            {
                Debug.Log("Want1, not needed for this object");
                animalCollision = true;
                
            }

            if(characterStored.wantInfo_2!= "")
            {
                if (gameObject.CompareTag("Neighbor"))
                {
                    if(other.gameObject.CompareTag("Neighbor"))
                    {
                        if(other.transform.parent.CompareTag("Pool") && gameObject.GetComponentInParent<CharacterStored>().animalRooms == "Pool")
                        {
                            animalRoom = true;
                            
                        }
                    }
                    if(other.gameObject.CompareTag("Neighbor"))
                    {
                        if(other.transform.parent.CompareTag("Kitchen") && gameObject.GetComponentInParent<CharacterStored>().animalRooms == "Kitchen")
                        {
                            animalRoom = true;
                            
                        }
                    }
                    if(other.gameObject.CompareTag("Neighbor"))
                    {
                        if(other.transform.parent.CompareTag("LivingRoom") && gameObject.GetComponentInParent<CharacterStored>().animalRooms == "LivingRoom")
                        {
                            animalRoom = true;
                           
                        }
                    }
                    if(other.gameObject.CompareTag("Neighbor"))
                    {
                        if(other.transform.parent.CompareTag("Garden") && gameObject.GetComponentInParent<CharacterStored>().animalRooms == "Garden")
                        {
                            animalRoom = true;
                            
                        }
                    }

                }
            }
            else
            {
                //no want 2 needed
                animalRoom = true;
                
            }

            if(characterStored.wantInfo_3!= "")
            {
                if (gameObject.CompareTag("Row"))
                {
                //   if(other.gameObject.CompareTag("Row") && //other gameobject collided is named row(rowneeded))
                }
                if (gameObject.CompareTag("Column"))
                {
                    //   if(other.gameObject.CompareTag("Column") && //other gameobject collided is named column(column needed))
                }
                //want 3 animal colum/row requiremet
            }
            else
            {
                animalColRow = true;
                
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
                
            }

            

                
        }
        
    }
    

    

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collider"))
        {
            return;
        }
        if (gameObject.CompareTag("Row") && other.gameObject.CompareTag("Row"))
        {
            animalCollision = false;
            
    
        }
        if (gameObject.CompareTag("Column") && other.gameObject.CompareTag("Column"))
        {
            animalCollision = false;
            
          
        }
        if (gameObject.CompareTag("Neighbor") && other.gameObject.CompareTag("Neighbor"))
        {
            animalCollision = false;
            
            
        }

    }

    public void CheckRequirements()
    {
        if(animalCollision == true && animalColRow == true && animalRoom == true && animalSmell == true)
        {
            animalManager.requirmentsMeet = true;
        }
        else
        {
            animalManager.requirmentsMeet = false;
        }
    }
}
