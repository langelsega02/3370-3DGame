using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject winPanel;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Instructions()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
