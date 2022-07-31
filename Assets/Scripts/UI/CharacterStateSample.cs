using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStateSample : MonoBehaviour
{
    public FloatVariable hpCharacter1;
    public FloatVariable hpCharacter2;
    public CharacterTypeVariable characterType;
    public Text hpText;
    public Text nameText;

    private void Update()
    {
        hpText.text = characterType.Value == CharacterType.Hihat ?
            hpCharacter1.Value.ToString() :
            hpCharacter2.Value.ToString();
        nameText.text = characterType.Value.ToString() + ": ";
    }
}
