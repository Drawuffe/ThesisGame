using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public bool biome1_Completed = false;
    public bool level1_Completed = false, level2_Completed = false, level3_Completed = false, level4_Completed = false;
    public bool level1_AnimalReqCompleted = false, level2_AnimalReqCompleted = false, level3_AnimalReqCompleted = false,level4_AnimalReqCompleted = false;
    public bool level1_PipeMin= false, level2_PipeMin= false, level3_PipeMin= false, level4_PipeMin= false;
    public int poolPieces, kitchenPieces, livingRoomPieces, gardenPieces;
    public static LevelManager Instance {  get; private set; }

    void Awake()
    {
        if(Instance != null && Instance !=this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        poolPieces = 4;
        kitchenPieces = 4;
        livingRoomPieces = 4;
        gardenPieces = 4;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    void LevelOneCompletion()
    {
        level1_Completed = true;
        //turn on level 2 button
        
    }

    void LevelTwoCompletion()
    {
        
    }

    void LevelThreeCompletion()
    {
        
    }

    void LevelFourCompletion()
    {
        
    }


}
