using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    public GameObject pauseMenu;

    void Update()
    {
        if (pauseMenu == null)
        {
            return;
        }

        PauseMenu();
    }

    public void LoadScene(int sceneIndex)
    {
        if (GameManager.instance.isPaused)
        {
            GameManager.instance.UnPauseGame();
        }
        else
        {
            return;
        }
        SceneManager.LoadScene(sceneIndex);
    }

    public void PauseMenu()
    {
        if (Input.GetButtonDown("Pause"))
        {
            GameManager.instance.isPaused = !GameManager.instance.isPaused;
            pauseMenu.SetActive(GameManager.instance.isPaused);

            if (GameManager.instance.isPaused)
            {
                GameManager.instance.PauseGame();
            }
            else
            {
                GameManager.instance.UnPauseGame();
            }
        }
    }



}
