using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Scriptable Objects/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public string characterName;
    public string wantInfo_1;
    public string wantInfo_2;
    public string wantInfo_3;
    public string wantInfo_4;
    public Sprite characterSprite;
    public int points;
    public Sprite happyPlacedSprite;
    public Sprite sadPlacedSprite;
    public bool checkRow, checkCol, checkNeigh;
    public string animalCollision;
    public string animalRooms;
    public string animalRow;
    public string animalCol;
    public bool animalSmells;
    public bool animalDoesNotLikeSmells;
}
