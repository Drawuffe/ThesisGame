using UnityEngine;
using UnityEngine.UI;

public class AnimalManager : MonoBehaviour
{

    public bool checkRow;
    public bool checkCol;
    public bool checkNeigh;
    public string animalName;
    public float rowDistance, colDistance, neighDistance, defaultDistance = 1000f;
    private float distance;
    public LayerMask hitLayers;
    private Transform colCollider, rowCollider, neighCollider;
    public bool requirmentsMeet;


    void Start()
    {
        for (int i=0; i<transform.childCount; i++)
        {
            if(transform.GetChild(i).CompareTag("Row"))
            {
                rowCollider = transform.GetChild(i);
                
            }
            if(transform.GetChild(i).CompareTag("Column"))
            {
                colCollider = transform.GetChild(i);
               
            }
            if(transform.GetChild(i).CompareTag("Neighbor"))
            {
                neighCollider = transform.GetChild(i);
                
                
            }
            
        }
        
        StartColliders();
    }
    public void StoreWants(string name, bool row, bool col, bool neigh)
    {
        animalName = name;
        checkRow = row;
        checkCol = col;
        checkNeigh = neigh;

       //StartColliders();
    }

    public void StartColliders()
    {   
        if (checkRow == true)
        {
            rowCollider.gameObject.SetActive(true);
        }
        else
        {
            Destroy(rowCollider.gameObject);
        }
        if (checkCol == true)
        {
            colCollider.gameObject.SetActive(true); 
        }
        else
        {
            Destroy(colCollider.gameObject);
        }
        if (checkNeigh == true)
        {
            neighCollider.gameObject.SetActive(true); 
        }
        else
        {
            Destroy(neighCollider.gameObject); 
        }
        
    }

}
