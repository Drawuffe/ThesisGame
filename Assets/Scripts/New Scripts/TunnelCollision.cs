using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class TunnelCollision : MonoBehaviour
{
    public bool colliding = false;
    


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log ("Collision");
        // Try to get the same script from the object passing through
        if (other.gameObject.CompareTag("Collider"))
        {
            colliding = true;
            Debug.Log($"{gameObject.name} overlapped with another object running the SAME script: {other.gameObject.name}");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
        Debug.Log("Collision removed");

    }

    

    
}



       


