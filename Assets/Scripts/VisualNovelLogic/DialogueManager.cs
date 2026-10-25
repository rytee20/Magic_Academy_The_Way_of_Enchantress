using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class DialogueLine
{
    public string characterName;
    public string text;
}

public class DialogueManager : MonoBehaviour
{
    private Player player;

    public List<Image> backgrounds;

    private Character dandalion;
    private Character magnus;

    private int scene;
    TextAsset textAsset;
    private string filePath;

    public Dialogue dialogue;
    private List<DialogueLine> dialogues;
    private int currentDialogueIndex = 0;

    public event Action OnDialogueFinished;

    /*void Awake()
    {
        InitializeComponents();
    }*/

    public void StartDialogue()
    {
        InitializeComponents();
        ShowNextDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextDialogue();
        }
    }

    private void InitializeComponents()
    {
        //SetPlayer(new Player());

        LoadBackground();

        GetCharacters();

        ReadDialogue();
        dialogues = LoadDialogues();
    }

    private void LoadBackground()
    {
        backgrounds[scene-1].gameObject.SetActive(true);
        for (int i = 0; i < backgrounds.Count; i++)
        {
            if (i!=scene-1) backgrounds[i].gameObject.SetActive(false);
        }
    }

    private void GetCharacters()
    {
        dandalion = GameObject.Find("Dandalion").GetComponent<Character>();
        magnus = GameObject.Find("Magnus").GetComponent<Character>();
        dandalion.SetCharacterType(CharacterType.Dandalion);
        magnus.SetCharacterType(CharacterType.Magnus);

        switch (scene)
        {
            case 1:
                dandalion.image.gameObject.SetActive(true);
                magnus.image.gameObject.SetActive(true);
                break;
            case 2:
                dandalion.image.gameObject.SetActive(true);
                magnus.image.gameObject.SetActive(false);
                break;
            case 3:
                dandalion.image.gameObject.SetActive(true);
                magnus.image.gameObject.SetActive(false);
                break;
            case 4:
                dandalion.image.gameObject.SetActive(false);
                magnus.image.gameObject.SetActive(true);
                break;
            case 5:
                dandalion.image.gameObject.SetActive(false);
                magnus.image.gameObject.SetActive(true);
                break;
            case 6:
                dandalion.image.gameObject.SetActive(true);
                magnus.image.gameObject.SetActive(false);
                break;
            case 7:
                dandalion.image.gameObject.SetActive(false);
                magnus.image.gameObject.SetActive(true);
                break;
            default:
                throw new ArgumentException("Unknown scene");
        }
    }

    private void ReadDialogue()
    {
        switch (scene)
        {
            case 1:
                textAsset = Resources.Load<TextAsset>("Text/Scene1");
                filePath = "Assets/Resources/Text/Scene1.txt";
                break;
            case 2:
                textAsset = Resources.Load<TextAsset>("Text/Scene21");
                filePath = "Assets/Resources/Text/Scene21.txt";
                break;
            case 3:
                textAsset = Resources.Load<TextAsset>("Text/Scene31");
                filePath = "Assets/Resources/Text/Scene31.txt";
                break;
            case 4:
                textAsset = Resources.Load<TextAsset>("Text/Scene22");
                filePath = "Assets/Resources/Text/Scene22.txt";
                break;
            case 5:
                textAsset = Resources.Load<TextAsset>("Text/Scene32");
                filePath = "Assets/Resources/Text/Scene32.txt";
                break;
            case 6:
                textAsset = Resources.Load<TextAsset>("Text/Scene41");
                filePath = "Assets/Resources/Text/Scene41.txt";
                break;
            case 7:
                textAsset = Resources.Load<TextAsset>("Text/Scene42");
                filePath = "Assets/Resources/Text/Scene42.txt";
                break;
            default:
                throw new ArgumentException("Unknown scene");
        }
    }

    public List<DialogueLine> LoadDialogues()
    {
        List<DialogueLine> dialogues = new List<DialogueLine>();

        if (textAsset != null)
        {
            string[] lines = textAsset.text.Split('\n');
            foreach (string line in lines)
            {
                string[] parts = line.Split(new[] { ':' }, 2);
                if (parts.Length == 2)
                {
                    DialogueLine dialogueLine = new DialogueLine();
                    dialogueLine.characterName = parts[0].Trim();
                    dialogueLine.text = parts[1].Trim();
                    dialogues.Add(dialogueLine);
                }
            }
        }
        else
        {
            Debug.LogError("Dialogue file not found: " + filePath);
        }

        return dialogues;
    }

    public void ShowNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Count)
        {
            dialogue.DisplayText(dialogues[currentDialogueIndex].characterName, dialogues[currentDialogueIndex].text);
            currentDialogueIndex++;
        }
        else
        {
            OnDialogueFinished?.Invoke();
        }
    }

    public void IncreaseCurrentDialogueIndex()
    {
        currentDialogueIndex++;
    }

    public void SetScene(int s)
    {
        scene = s;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void SetPlayer(Player p)
    {
        player = p;
    }
}
