using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public void MenuOpen(GameObject menu)
    {
        menu.SetActive(true);
    }
    public void CloseMenu(GameObject menu)
    {
        menu.SetActive(false);
    }
    public void onPause(GameObject pauseMenu)
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
        }
        else if (!pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(true);
        }
    }
}
