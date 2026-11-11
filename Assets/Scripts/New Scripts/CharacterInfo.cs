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
    private string selectedName, selectedWant1, selectedWant2, selectedWant3;
    private Sprite selectedSprite;
    private int selectedPoints;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentTransform = GetComponent<Transform>();
        SpawnAnimals();
    }

    void SpawnAnimals()
    {


        for (int i = characters.Length - 1; i >= 0; i--) 
        {
            //extracts all the information from all the animals in the list for the level and saves the information
            //on a script attached to every item.
            CharacterSO selectedCharacter = characters[i];
            currentInstance = Instantiate(animalPrefab, parentTransform);
            selectedName = selectedCharacter.characterName;
            selectedSprite = selectedCharacter.characterSprite;
            selectedWant1 = selectedCharacter.wantInfo_1;
            selectedWant2 = selectedCharacter.wantInfo_2;
            selectedWant3 = selectedCharacter.wantInfo_3;
            selectedPoints = selectedCharacter.points;
            Image image = currentInstance.GetComponent<Image>();
            image.sprite = selectedSprite;
            CharacterStored characterStored = currentInstance.GetComponent<CharacterStored>();
            GameManager.Instance.animalList.Add(currentInstance);
            characterStored.StoreValues(selectedName, selectedWant1, selectedWant2, selectedWant3, selectedSprite, selectedPoints);
        }

    }


}
