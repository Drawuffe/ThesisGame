using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class TunnelCollision : MonoBehaviour
{
    public bool colliding = false;
    

    //checks for colliders collision with one another.
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log ("Collision");
        if (other.gameObject.CompareTag("Collider"))
        {
            colliding = true;
           // Debug.Log($"{gameObject.name} overlapped with another object running the SAME script: {other.gameObject.name}");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
        //Debug.Log("Collision removed");

    }

    

    
}



       


