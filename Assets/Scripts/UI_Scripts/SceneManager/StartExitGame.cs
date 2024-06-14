using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class StartExitGame : MonoBehaviour
{

    public void StartGame(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    public void ExitGame()
    {
        Application.Quit();
        EditorApplication.isPaused = true;
    }
}
