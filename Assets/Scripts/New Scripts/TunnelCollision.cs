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
        if (other.CompareTag("Column"))
        {
            return;
        }
        if(other.CompareTag("Row"))
        {
            return;
        }
        if(other.CompareTag("Neighbor"))
        {
            return;
        }
        if (other.gameObject.CompareTag("Collider"))
        {
            colliding = true;
            //Debug.Log($"{gameObject.name} overlapped with another object running the SAME script: {other.gameObject.name}");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Column"))
        {
            return;
        }
        if(other.CompareTag("Row"))
        {
            return;
        }
        if(other.CompareTag("Neighbor"))
        {
            return;
        }
        if (other.gameObject.CompareTag("Collider"))
        {
            colliding = false;
            //Debug.Log($"{gameObject.name} overlapped with another object running the SAME script: {other.gameObject.name}");
        }

    }

    

    
}



       


