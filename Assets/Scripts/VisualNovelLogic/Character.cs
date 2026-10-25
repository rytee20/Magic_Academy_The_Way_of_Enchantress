using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterType
{
    Dandalion = 0,
    Magnus = 1,
    Null = 3
}

public class Character : MonoBehaviour
{
    private CharacterType characterType;

    public Image image;

    public void SetCharacterType(CharacterType type)
    {
        characterType = type;
    }
}
