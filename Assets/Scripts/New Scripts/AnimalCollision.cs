using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class AnimalCollision : MonoBehaviour
{
    private CharacterStored characterStored;
    private AnimalManager animalManager;

    public bool animalCollision;
    void Start()
    {
        characterStored = GetComponentInParent<CharacterStored>();
        animalManager = GetComponentInParent<AnimalManager>();

    }

    void Update()
    {
        if(animalCollision = false)
        {
            animalManager.requirmentsMeet = false;
        }
        else
        {
            animalManager.requirmentsMeet = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent != null)
        {
            
            if (transform.parent.parent != null)
            {
                Transform grandparent = transform.parent.parent;
                if(grandparent.name == "Characters")
                {
                    //Debug.Log("Object has not been moved yet");
                    animalCollision = false;
                  
                }
                else
                {
                    if(other.gameObject.GetComponentInParent<CharacterStored>().wantInfo_1!= null)
                    {
                        if (gameObject.CompareTag("Row"))
                        {
                        
                            if (other.gameObject.CompareTag("Row"))
                            {
                                
                                if(other.gameObject.GetComponentInParent<CharacterStored>().characterName == characterStored.animalCollsionName)
                                { 
                                    animalCollision = true;
                                    
                                }
                                
                            }
                       
                        }
                        if (gameObject.CompareTag("Column"))
                        {
                            if (other.gameObject.CompareTag("Column"))
                            {
                                if(other.gameObject.GetComponentInParent<CharacterStored>().characterName == characterStored.animalCollsionName)
                                { 
                                    animalCollision = true;
                                    
                                }
                            }
                        
                        }
                        if (gameObject.CompareTag("Neighbor"))
                        {
                            if (other.gameObject.CompareTag("Neighbor"))
                            {
                                if(other.gameObject.GetComponentInParent<CharacterStored>().characterName == characterStored.animalCollsionName)
                                { 
                                    animalCollision = true;
                                    
                                }
                            }
                    
                        }
                    }
                    else
                    {
                        Debug.Log("Want1, not needed for this object");
                    }

                    if(other.gameObject.GetComponentInParent<CharacterStored>().wantInfo_2!= null)
                    {
                        if (gameObject.CompareTag("Neighbor"))
                        {
                        
                            //if(gameObject.GetComponentInParent<CharacterStored>().animalRooms == other.gameObject.GetComponentInParent<//roomCollisionScript))
                            //{ 
                            //    animalCollision = true;
                                    
                            //}
                                
                            
                       
                        }
                    }
                    else
                    {
                        //no want 2 needed
                    }
                    if(other.gameObject.GetComponentInParent<CharacterStored>().wantInfo_3!= null)
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
                        //no want 3 needed
                    }
                    if(other.gameObject.GetComponentInParent<CharacterStored>().wantInfo_4!= null)
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
                        //no want 4 requirement
                    }

                    
                }
            }
            else
            {
                Debug.Log("The parent has no parent (it is a root-level parent).");

            }
        }
        else
        {
            Debug.Log("This object has no parent.");
        }

        
        
    }

    private void OnTriggerExit(Collider other)
    {
        animalCollision = false;
        //Debug.Log("Collision removed");

    }
}
