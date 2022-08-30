using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSelected", menuName = "Agent/CharacterSelected")]
public class CharacterSelectedSO : ScriptableObject
{
    [Header("Character Selected")]
    [Space]
    public CharacterType characterType = CharacterType.Hithat;
}

public enum CharacterType
{
    Hithat,
    Drums
}