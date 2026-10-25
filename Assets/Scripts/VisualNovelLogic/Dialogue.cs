using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour 
{
    public TMP_Text characterName;
    public TMP_Text dialogueText;

    public void DisplayText(string name, string text)
    {
        characterName.text = name;
        dialogueText.text = text;
    }
}

