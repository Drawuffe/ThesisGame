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
    public RectTransform parentTransform;
    public GameObject newChild;




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

    public void BurrowPieceFound()
    {
        Blueprints selectedBurrow = GameManager.Instance.blueprints[pieceClicked];
        print(selectedBurrow);

        selectedName = selectedBurrow.name;
        selectedSprite = selectedBurrow.image;
        GameManager.Instance.SpawnPiece(selectedName, selectedSprite);
    }

    public void SpawnPiece(string burrowName, Sprite burrowImage)
    {
        
        Debug.Log(burrowName);
        newChild = Instantiate(burrowPrefab);
        Image image = newChild.GetComponent<Image>();
        newChild.transform.SetParent(parentTransform, true);
        image.sprite = burrowImage;
        Debug.Log("Piece Spawned");

    
    }
}
