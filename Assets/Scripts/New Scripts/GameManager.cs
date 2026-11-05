using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    [Header("Piece Total for Level")]
    public int cornerPieces = 0;
    public int straightPieces = 0;
    public int threePieces = 0;
    public int fourPieces = 0;
    [Header("Button Text for Piece Menu")]
    public TextMeshProUGUI cornerText, straightText, threeText, fourText;
    private int startCornerPieces, startStraightPieces, startThreePieces, startFourPieces;
    [Header("List of Possible Pieces")]
    public Blueprints[] blueprints;
    public int pieceClicked = 0;
    private string selectedName;
    private Sprite selectedSprite;
    public GameObject burrowPrefab;
    public Transform parentTransform;
    public GameObject newChild;
    private Vector3 worldPosition;
    private GameObject currentInstance;
    public Transform instantiateParent;
    public GameObject pieceButtons;
    public List<GameObject> addedBurrowList = new List<GameObject>();
    public List<GameObject> burrowColliders = new List<GameObject>();
    public List<GameObject> allColliders =  new List<GameObject>();
    public List<GameObject> burrowHoles =  new List<GameObject>();
    public Image completionImage;
    public AudioController audioController;
    



    private void Awake()
    {
        if(Instance != null && Instance !=this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        UpdateBurrowButton();

        startCornerPieces = cornerPieces;
        startStraightPieces = straightPieces;
        startThreePieces = threePieces;
        startFourPieces = fourPieces;
        
        
  
    }
    void Start()
    {
        pieceButtons.SetActive(false);
        completionImage.enabled = false;
        AudioController audioController = GetComponent<AudioController>();
        BurrowAdd();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            foreach (GameObject obj in addedBurrowList)
{
            if (obj != null)
            {
                Destroy(obj);
            }
}
            addedBurrowList.Clear();
            cornerPieces = startCornerPieces;
            Reset();
        }

    
    }

    public void BurrowPieceFound(int piece)
    {
        //determines what piece the player wants to spawn and finds the piece info in the scriptable object.
        pieceClicked = piece;
        if(piece is 0)
        {
            if(cornerPieces > 0)
            {
                cornerPieces -= 1;
                cornerText.text = cornerPieces.ToString();
                PieceFound();
                

            }
   
        }
        if(piece is 1)
        {
            if(straightPieces > 0)
            {
                straightPieces -= 1;
                PieceFound();
                straightText.text = straightPieces.ToString();

            }
  
        }
        if(piece is 2)
        {
            if(threePieces > 0)
            {
                threePieces -= 1;
                PieceFound();
                threeText.text = threePieces.ToString();

            }
        }
        if(piece is 3)
        {
            if(fourPieces > 0)
            {
                fourPieces -= 1;
                PieceFound();
                fourText.text = fourPieces.ToString();

            }
        }
        else
        {
            Debug.Log("no piece");
        }

    }

    private void PieceFound()
    {
        //finds the piece in the list of objects
        Blueprints selectedBurrow = blueprints[pieceClicked];
        print(selectedBurrow);

        selectedName = selectedBurrow.name;
        selectedSprite = selectedBurrow.image;
        StartPlacing(selectedName, selectedSprite);
    }


    public void StartPlacing(string burrowName, Sprite burrowImage)
    {
        //instantiates the objects depending on what the index was.
        currentInstance = Instantiate(burrowPrefab,instantiateParent);
        addedBurrowList.Add(currentInstance);
        int index = addedBurrowList.IndexOf(currentInstance);
        Image image = currentInstance.GetComponent<Image>();
        image.sprite = burrowImage;
    
        if(burrowName == "Corner")
        {
            Transform childTransform = currentInstance.transform.GetChild(1); 
            Destroy(childTransform.gameObject);
            
            childTransform = currentInstance.transform.GetChild(2);
            Destroy(childTransform.gameObject);
            
        }
        if(burrowName == "Straight")
        {
            Transform childTransform = currentInstance.transform.GetChild(0); 
            Destroy(childTransform.gameObject);
            childTransform= currentInstance.transform.GetChild(2);
            Destroy(childTransform.gameObject);
            
        }
        if(burrowName == "Three")
        {
            Transform childTransform = currentInstance.transform.GetChild(0); 
            Destroy(childTransform.gameObject);
            
        }
        
        if (currentInstance != null)
        {
            foreach (Transform childTransform in currentInstance.transform)
            {
                burrowColliders.Add(childTransform.gameObject);
            }
        }
        BurrowInfo burrowInfo = currentInstance.GetComponent<BurrowInfo>();
        burrowInfo.AssignColliders(burrowColliders);
        burrowInfo.StoreInfo(burrowName, burrowImage, index);
        pieceButtons.SetActive(false);
        allColliders.AddRange(burrowColliders);
        burrowColliders.Clear();
        CleanList(allColliders);
        audioController.PlayAudio(1);
        CheckForCompletion();

    }

    public void UpdateBurrowButton()
    {
        //updates the values of the burrow piece menu, showing what pieces are available to the player.
        cornerText.text = cornerPieces.ToString();
        straightText.text = straightPieces.ToString();
        threeText.text = threePieces.ToString();
        fourText.text = fourPieces.ToString();
    }

    public void Reset()
    {
        //resets the game and all its values
        cornerPieces = startCornerPieces;
        straightPieces = startStraightPieces;
        threePieces = startThreePieces;
        fourPieces = startFourPieces;
        UpdateBurrowButton();
        allColliders.Clear();
        BurrowAdd();
    }

    public void CleanList(List<GameObject> list)
    {
        //clears out the burrow list.
        for (int i = list.Count - 1; i >= 0; i--)
{
        if (list[i] == null)
        {
            list.RemoveAt(i); 
        }
}
    }

    public void CheckForCompletion()
    {
        //checks for the puzzle completion
        if(AreAllConditionsMet() == true)
        {
            Debug.Log("complete");
            WhenComplete();
        }
        else
        {
            Debug.Log("not complete");
            completionImage.enabled = false;
        }
    }

    public bool AreAllConditionsMet()
    {
        foreach (GameObject go in allColliders)
        {
            if (go == null) continue; 

  
            if (go.TryGetComponent<TunnelCollision>(out var script))
            {

                if (!script.colliding)
                {
                    return false; 
                    
                }
            }
            else
            {

                return false; 
            }
        }

        return true; 
    }

    private void WhenComplete()
    {

        completionImage.enabled = true;
        audioController.PlayAudio(4);
    }

    private void BurrowAdd()
    {
        foreach(GameObject go in burrowHoles)
        {
            allColliders.Add(go);
        }
    }

    

    
}
