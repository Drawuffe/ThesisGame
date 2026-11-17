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
    public TextMeshProUGUI cornerText, straightText, threeText, fourText, poolText, kitchenText, livingRoomText, gardenText;
    private int startCornerPieces, startStraightPieces, startThreePieces, startFourPieces;
    public int startPool = 0, startKitchen=0, startLivingRoom=0, startGarden=0;
    public Blueprints[] blueprints;
    public int pieceClicked = 0;
    private string selectedName;
    private Sprite selectedSprite;
    private bool selectedRoom;
    public GameObject burrowPrefab, roomPrefab;
    public Transform parentTransform;
    public GameObject newChild;
    private Vector3 worldPosition;
    private GameObject currentInstance;
    public Transform instantiateParent;
    public GameObject pieceButtons;
    public GameObject roomPieceButtons;
    public List<GameObject> addedBurrowList = new List<GameObject>();
    public List<GameObject> addedRoomList = new List<GameObject>();
    public List<GameObject> burrowColliders = new List<GameObject>();
    public List<GameObject> allColliders =  new List<GameObject>();
    public List<GameObject> burrowHoles =  new List<GameObject>();
    public List<GameObject> burrowHomes =  new List<GameObject>();
    public List<GameObject> animalList =  new List<GameObject>();
    public Image completionImage;
    public Image completionImageAnimals;
    public Image completionImageAnimalRequirements;
    public Image completionImagePipeRequirements;
    public AudioController audioController;
    public bool characterMoving = false;
    public CharacterInfo characterInfo;
    



    private void Awake()
    {
        if(Instance != null && Instance !=this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        
        
        
  
    }
    void Start()
    {
        pieceButtons.SetActive(false);
        roomPieceButtons.SetActive(false);
        completionImage.enabled = false;
        completionImageAnimals.enabled = false;
        AudioController audioController = GetComponent<AudioController>();
        startCornerPieces = cornerPieces;
        startStraightPieces = straightPieces;
        startThreePieces = threePieces;
        startFourPieces = fourPieces;
        startPool = LevelManager.Instance.poolPieces;
        startKitchen = LevelManager.Instance.kitchenPieces;
        startLivingRoom = LevelManager.Instance.livingRoomPieces;
        startGarden = LevelManager.Instance.gardenPieces;
        UpdateBurrowButton();
        pieceButtons.SetActive(false);
        roomPieceButtons.SetActive(false);
        BurrowAdd();
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            foreach (GameObject obj in animalList)
            {
                if (obj != null)
                {
                    foreach (Transform child in obj.transform)
                    {
                        AnimalCollision anCol = child.gameObject.GetComponent<AnimalCollision>();
                        anCol.animalCollision = false;
                        anCol.animalRoom = false;
                        anCol.animalColRow = false;
                        anCol.animalSmell = false;
                        
                    }

                    AnimalManager aniMan = obj.GetComponent<AnimalManager>();
                    aniMan.SetSpriteDefault();
                    
                }

            }
            foreach (GameObject obj in addedBurrowList)
            {
                if (obj != null)
                {
                    Destroy(obj);
                }
            }
            foreach (GameObject obj in addedRoomList)
            {
                if (obj != null)
                {
                    Destroy(obj);
                }
            }
            
            addedBurrowList.Clear();
            Reset();
        }

        CheckForCompletion();
    
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
        if(piece is 4)
        {
            if(startPool > 0)
            {
                startPool -= 1;
                poolText.text = startPool.ToString();
                PieceFound();
        
                
            }
        }
        if(piece is 5)
        {
            if(startKitchen > 0)
            {
                startKitchen -= 1;
                kitchenText. text = startKitchen.ToString();
                PieceFound();
        
            }
        }
        if(piece is 6)
        {
            if(startLivingRoom > 0)
            {
                startLivingRoom -= 1;
                livingRoomText.text = startLivingRoom.ToString();
                PieceFound();
        
            }
        }
        if(piece is 7)
        {
            if(startGarden > 0)
            {
                startGarden -= 1;
                gardenText.text = startGarden.ToString();
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
        //finds the piece in the list of objects
        Blueprints selectedBurrow = blueprints[pieceClicked];
        print(selectedBurrow);

        selectedName = selectedBurrow.name;
        selectedSprite = selectedBurrow.image;
        selectedRoom = selectedBurrow.roomCheck;
        //add bool to check if its a room or a path
        StartPlacing(selectedName, selectedSprite, selectedRoom);
    }


    public void StartPlacing(string burrowName, Sprite burrowImage, bool isRoom)
    {
        if(isRoom == false)
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
        else
        {
            
            currentInstance = Instantiate(roomPrefab,instantiateParent);
            addedBurrowList.Add(currentInstance);
            Image image = currentInstance.GetComponent<Image>();
            image.sprite = burrowImage;
            addedRoomList.Add(currentInstance);
            RoomAddons roomAddons = currentInstance.GetComponent<RoomAddons>();
            roomAddons.StoreInfo(burrowName, burrowImage);
            roomPieceButtons.SetActive(false);
            audioController.PlayAudio(1);
            CheckForCompletion();
            
            
        }

    }

    public void UpdateBurrowButton()
    {
        //updates the values of the burrow piece menu, showing what pieces are available to the player.
        cornerText.text = cornerPieces.ToString();
        straightText.text = straightPieces.ToString();
        threeText.text = threePieces.ToString();
        fourText.text = fourPieces.ToString();
        poolText.text = startPool.ToString();
        kitchenText. text = startKitchen.ToString();
        livingRoomText.text = startLivingRoom.ToString();
        gardenText.text = startGarden.ToString();
    }

    public void Reset()
    {
        //resets the game and all its values
        cornerPieces = startCornerPieces;
        straightPieces = startStraightPieces;
        threePieces = startThreePieces;
        fourPieces = startFourPieces;
        startPool = LevelManager.Instance.poolPieces;
        startKitchen = LevelManager.Instance.kitchenPieces;
        startLivingRoom = LevelManager.Instance.livingRoomPieces;
        startGarden = LevelManager.Instance.gardenPieces;
        UpdateBurrowButton();
        allColliders.Clear();
        BurrowAdd();
        ReparentAnimals();

        
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
            
            WhenCompletePipes();
        }
        else
        {
            
            completionImage.enabled = false;
        }

        if(CheckAnimalCompletion() == true)
        {
            
            WhenCompleteAnimal();
        }
        else
        {
            completionImageAnimals.enabled = false;
        }
        if(AnimalRequirementCheck() == true)
        {
            WhenCompleteAnimalRequirement();
        }
        else
        {
            completionImageAnimalRequirements.enabled = false;
        }
    }

    public bool CheckAnimalCompletion()
    {

        return burrowHomes.All(obj => obj != null && obj.transform.Find("AnimalPrefab(Clone)") != null);

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

    public bool AnimalRequirementCheck()
    {
        foreach (GameObject go in animalList)
        {
            if (go == null) continue; 

  
            if (go.TryGetComponent<AnimalManager>(out var script))
            {
                
                if (!script.requirmentsMeet)
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

    private void WhenCompletePipes()
    {
        if(completionImage.enabled == false)
        {
            completionImage.enabled = true;
            audioController.PlayAudio(4);
        }
        else
        {
            //Debug.Log("already complete");
        }
       
    }

    private void WhenCompleteAnimal()
    {
        if(completionImageAnimals.enabled == false)
        {
            completionImageAnimals.enabled = true;
            audioController.PlayAudio(4);
        }
        else
        {
            //Debug.Log("already complete");
        }
    }
    private void WhenCompleteAnimalRequirement()
    {
        if(completionImageAnimalRequirements.enabled == false)
        {
            completionImageAnimalRequirements.enabled = true;
            audioController.PlayAudio(4);
        }
        else
        {
            //Debug.Log("already complete");
        }
    }



    private void BurrowAdd()
    {
        foreach(GameObject go in burrowHoles)
        {
            allColliders.Add(go);
        }
    }

    private void ReparentAnimals()
    {
        foreach(GameObject obj in animalList)
        {
            CharacterMovement characterMovement = obj.GetComponent<CharacterMovement>();
            characterMovement.transform.SetParent(characterMovement.originalTransform);
        }
    }

    

    
}
