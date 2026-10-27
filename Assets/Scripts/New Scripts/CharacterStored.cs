using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CharacterStored : MonoBehaviour, IPointerClickHandler
{
    public string characterName;
    public string wantInfo_1;
    public string wantInfo_2;
    public string wantInfo_3;
    public Sprite characterSprite;
    public int totalPoints;
    public CharacterText characterText;


    void Start()
    {
        characterText = GameObject.FindGameObjectWithTag("CharacterText").GetComponent<CharacterText>();
    }
    public void StoreValues(string name, string want1, string want2, string want3, Sprite characterImage, int points)
    {
        characterName = name;
        wantInfo_1 = want1;
        wantInfo_2 = want2;
        wantInfo_3 = want3;
        characterSprite = characterImage;
        totalPoints = points;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        characterText.characterImage.sprite = characterSprite;
        characterText.characterInfo.text = wantInfo_1;
        characterText.characterName.text = characterName;

    }


}
