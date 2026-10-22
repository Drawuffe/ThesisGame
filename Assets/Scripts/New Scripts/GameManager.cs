using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public int cornerPieces = 0;
    public int straightPieces = 0;
    public int threePieces = 0;
    public int fourPieces = 0;
    public Blueprints[] blueprints;
    public int pieceClicked = 0;
    private string selectedName;
    private Sprite selectedSprite;
    public GameObject burrowPrefab;
    public Transform parentTransform;
    public GameObject newChild;
    private Vector3 worldPosition;
    private GameObject currentInstance;
    public Transform tempParent;




    private void Awake()
    {
        if(Instance != null && Instance !=this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
  
    }

  

    public void BurrowPieceFound(int piece)
    {
        pieceClicked = piece;
        if(piece is 0)
        {
            if(cornerPieces > 0)
            {
                cornerPieces -= 1;
                PieceFound();

            }
   
        }
        if(piece is 1)
        {
            if(straightPieces > 0)
            {
                straightPieces -= 1;
                PieceFound();

            }
  
        }
        if(piece is 2)
        {
            if(threePieces > 0)
            {
                threePieces -= 1;
                PieceFound();

            }
        }
        if(piece is 3)
        {
            if(fourPieces > 0)
            {
                fourPieces -= 1;
                PieceFound();

            }
        }
        else
        {
            Debug.Log("no piece");
        }

    }

    private void PieceFound()
    {
        Blueprints selectedBurrow = blueprints[pieceClicked];
        print(selectedBurrow);

        selectedName = selectedBurrow.name;
        selectedSprite = selectedBurrow.image;
        StartPlacing(selectedSprite);
    }


    public void StartPlacing(Sprite burrowImage)
    {
        if (currentInstance != null) return;

        // Instantiate the prefab
        currentInstance = Instantiate(burrowPrefab,parentTransform);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; 
        currentInstance.transform.position = mousePos;

        Image image = currentInstance.GetComponent<Image>();
        image.sprite = burrowImage;

    }
}
