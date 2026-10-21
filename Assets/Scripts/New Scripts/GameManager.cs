using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int cornerPieces = 0;
    public int straightPieces = 0;
    public int threePieces = 0;
    public int fourPieces = 0;
    public static GameManager Instance {  get; private set; }


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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
