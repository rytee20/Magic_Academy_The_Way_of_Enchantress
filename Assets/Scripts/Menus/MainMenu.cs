using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void NewGame()
    {
        Game game = FindObjectOfType<Game>();
        if (game != null)
        {
            game.StartGame();
        }
        else Debug.Log("Нет игры");
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
}
