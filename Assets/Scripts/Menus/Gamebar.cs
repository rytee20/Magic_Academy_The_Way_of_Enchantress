using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamebar : MonoBehaviour
{
    public void OpenGameMenu()
    {
        SceneManager.LoadScene(1);
    }
}
