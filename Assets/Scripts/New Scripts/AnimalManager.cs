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
    private CharacterStored characterStored;
    public Image currentImage;
    private Sprite happySprite, sadSprite;


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


    public void ChangeAnimalSprite()
    {
        characterStored = GetComponent<CharacterStored>();
        currentImage = GetComponent<Image>();

        
        
        if(requirmentsMeet == true)
        {
            
            print(characterStored.characterName + "requirements complete");
            currentImage.sprite = happySprite;
            
        }
        else
        {
            currentImage.sprite = sadSprite;
        }
        
        
        
    }

    public void SetSpriteDefault()
    {
        characterStored = GetComponent<CharacterStored>();
        currentImage = GetComponent<Image>();
        currentImage.sprite = characterStored.characterSprite;
    }
    public void StoreWants(string name, bool row, bool col, bool neigh, Sprite happyImage, Sprite sadImage)
    {
        animalName = name;
        checkRow = row;
        checkCol = col;
        checkNeigh = neigh;
        happySprite = happyImage;
        sadSprite = sadImage;

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

        GameManager.Instance.animalList.Add(this.gameObject);
        
    }

}
