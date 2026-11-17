using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CharacterInfo : MonoBehaviour
{
    public CharacterSO[] characters;
    private GameObject currentInstance;
    public GameObject animalPrefab;
    private Transform parentTransform;
    public string selectedName, selectedCollisionName;
    private string selectedWant1, selectedWant2, selectedWant3, selectedWant4;
    private string animalRoom, animalRows, animalColumns;
    private bool animalSmell, animalNoSmells;
    private bool col_, row_, neigh_;
    private Sprite selectedSprite, selectedHappy, selectedSad;
    private int selectedPoints;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentTransform = GetComponent<Transform>();
        SpawnAnimals();
    }

    public void SpawnAnimals()
    {


        for (int i = characters.Length - 1; i >= 0; i--) 
        {
            //extracts all the information from all the animals in the list for the level and saves the information
            //on a script attached to every item.
            CharacterSO selectedCharacter = characters[i];
            currentInstance = Instantiate(animalPrefab, parentTransform);
            selectedName = selectedCharacter.characterName;
            selectedSprite = selectedCharacter.characterSprite;
            selectedHappy = selectedCharacter.happyPlacedSprite;
            selectedSad = selectedCharacter.sadPlacedSprite;
            selectedWant1 = selectedCharacter.wantInfo_1;
            selectedWant2 = selectedCharacter.wantInfo_2;
            selectedWant3 = selectedCharacter.wantInfo_3;
            selectedWant4 = selectedCharacter.wantInfo_4;
            selectedPoints = selectedCharacter.points;
            animalRoom = selectedCharacter.animalRooms;
            animalColumns = selectedCharacter.animalCol;
            animalRows = selectedCharacter.animalRow;
            animalSmell = selectedCharacter.animalSmells;
            animalNoSmells = selectedCharacter.animalDoesNotLikeSmells;
            col_ = selectedCharacter.checkCol;
            row_ = selectedCharacter.checkRow;
            neigh_ = selectedCharacter.checkNeigh;
            Image image = currentInstance.GetComponent<Image>();
            image.sprite = selectedSprite;
            selectedCollisionName = selectedCharacter.animalCollision;
            CharacterStored characterStored = currentInstance.GetComponent<CharacterStored>();

            characterStored.StoreValues(selectedName, selectedWant1, selectedWant2, selectedWant3, selectedWant4, selectedSprite, selectedPoints, selectedCollisionName, 
            animalRoom, animalRows, animalColumns, animalSmell, animalNoSmells);
            AnimalManager animalManager = currentInstance.GetComponent<AnimalManager>();
            animalManager.StoreWants(selectedName, row_, col_, neigh_, selectedHappy, selectedSad);
        }

    }


}
