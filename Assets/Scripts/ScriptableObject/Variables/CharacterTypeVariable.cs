
using System;
using UnityEngine;

[CreateAssetMenu]
[Serializable]
public class CharacterTypeVariable : ScriptableObject
{
    public CharacterType Value;
}

public enum CharacterType
{
    Hihat,
    Drums
}