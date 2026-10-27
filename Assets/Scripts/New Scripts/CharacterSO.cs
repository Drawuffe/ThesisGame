using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Scriptable Objects/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public string characterName;
    public string wantInfo_1;
    public string wantInfo_2;
    public string wantInfo_3;
    public Sprite characterSprite;
    public int points;
}
