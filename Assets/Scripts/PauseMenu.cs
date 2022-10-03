using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Settings settings;

    private GameObject[] spawners;

    private void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner"); // different ingredient spawners in midground
    }

    public void navButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit the application.");
    }
    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        foreach (GameObject spawner in spawners) // disable spawners to avoid dragging
        {
            spawner.SetActive(false);
        }

        settings.SwapMusic(0);
        Debug.Log("pause");
    }
    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        foreach (GameObject spawner in spawners) // disable spawners to avoid dragging
        {
            spawner.SetActive(true);
        }

        settings.SwapMusic(1);
    }

    public void openPanel()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }


    }
}