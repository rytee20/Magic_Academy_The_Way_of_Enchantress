using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    private Player player;

    private DialogueManager dialogueManager;
    private SceduleManager sceduleManager;

    private int currentScene;

    private bool dandalionFirstScene = false;
    private bool magnusFirstScene = false;
    private bool dandalionRomanticScene = false;
    private bool magnusRomanticScene = false;
    private bool dandalionFinalScene = false;
    private bool magnusFinalScene = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        player = new Player();
        StartDialogueScene(1);
    }

    public void StartDialogueScene(int scene)
    {
        currentScene = scene;
        StartCoroutine(LoadSceneAsync("Dialogue", OnDialogueSceneLoaded));
    }

    public void StartHomeScene()
    {
        StartCoroutine(LoadSceneAsync("Home", OnHomeSceneLoaded));
    }

    private IEnumerator LoadSceneAsync(string sceneName, System.Action callback)
    {
        Debug.Log($"Загрузка сцены: {sceneName}");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Debug.Log($"Сцена {sceneName} загружена");
        callback?.Invoke();
    }

    private void OnDialogueSceneLoaded()
    {
        Debug.Log("Сцена диалога загружена. Попытка найти DialogueManager.");
        dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager != null)
        {
            Debug.Log("DialogueManager загружен.");
            dialogueManager.SetScene(currentScene);
            dialogueManager.SetPlayer(player);
            dialogueManager.StartDialogue();
            dialogueManager.OnDialogueFinished += HandleDialogueFinished;
        }
        else
        {
            Debug.LogError("DialogueManager not found in the DialogueScene");
        }
    }

    private void HandleDialogueFinished()
    {
        Debug.Log("Диалог завершен. Очистка состояния.");
        dialogueManager.OnDialogueFinished -= HandleDialogueFinished;

        Cleanup();

        if (currentScene == 6 || currentScene == 7)
        {
            EndGame();
        } else 
        { 
            StartHomeScene(); 
        }
    }

    private void Cleanup()
    {
        Debug.Log("Очистка динамически созданных объектов и других ресурсов.");
        if (dialogueManager != null)
        {
            Destroy(dialogueManager);
        }
    }

    private void OnHomeSceneLoaded()
    {
        sceduleManager = FindObjectOfType<SceduleManager>();
        if (sceduleManager != null)
        {
            Debug.Log("SceduleManager найден.");
            sceduleManager.SetPlayer(player);
            sceduleManager.StartScedule();
            sceduleManager.OnScheduleComplete += () =>
            {
                int completedCycles = sceduleManager.GetCompletedCycles();
                if (player.GetEnergyPoints() <= 0)
                {
                    EndGame();
                }
                else if (completedCycles >= 3)
                {
                    if (!dandalionFirstScene && completedCycles == 3)
                    {
                        dandalionFirstScene = true;
                        StartDialogueScene(2);
                    }
                    else if (!magnusFirstScene && completedCycles == 6)
                    {
                        magnusFirstScene = true;
                        StartDialogueScene(4);
                    }
                    else if (!dandalionRomanticScene && completedCycles > 3 && player.GetDandalionPoints() >= 40)
                    {
                        dandalionRomanticScene = true;
                        StartDialogueScene(3);
                    }
                    else if (!magnusRomanticScene && completedCycles > 6 && player.GetMagnusPoints() >= 40)
                    {
                        magnusRomanticScene = true;
                        StartDialogueScene(5);
                    }
                    else if (completedCycles == 16 && !dandalionFinalScene && player.GetStudyPoints(0) > 200 && player.GetStudyPoints(1) > 200 &&
                        player.GetStudyPoints(2) > 200 && player.GetDandalionPoints() >= 40 &&
                        player.GetDandalionPoints() > player.GetMagnusPoints())
                    {
                        StartDialogueScene(6);
                        dandalionFinalScene = true;
                    }
                    else if (completedCycles == 16 && !magnusFinalScene && player.GetStudyPoints(0) > 200 && player.GetStudyPoints(1) > 200 &&
                        player.GetStudyPoints(2) > 200 && player.GetMagnusPoints() >= 40 &&
                        player.GetMagnusPoints() > player.GetDandalionPoints())
                    {
                        StartDialogueScene(7);
                        magnusFinalScene = true;
                    }
                }
            };
        }
        else
        {
            Debug.LogError("SceduleManager not found in the HomeScene");
        }
    }

    private void EndGame()
    {
        GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject go in gameObjects)
        {
            if (go != Camera.main.gameObject && go.name != "ExitButton")
            {
                Destroy(go);
            }
        }

        SceneManager.LoadScene(3);
    }
}

