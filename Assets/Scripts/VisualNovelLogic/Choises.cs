/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Choises : MonoBehaviour
{
    public Button[] optionButtons;

    void Awake()
    {
        HideChoises();
    }

    public void ShowOptions(List<DialogueOption> options)
    {
        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < options.Count)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<Text>().text = options[i].text;
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => OnOptionSelected(options[i].effect, options[i].character));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnOptionSelected(int effect, int character)
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

        if (effect != 0)
        {
            dialogueManager.GetPlayer().ChangeRelationshipPoints(effect, character);
        }

        HideChoises();
        dialogueManager.IncreaseCurrentDialogueIndex();
        dialogueManager.ShowNextDialogue();
    }

    private void HideChoises()
    {
        foreach (Button button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }
    }
}*/
