using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject deathScreen;
    public GameObject loadingScreen;

    public float waitingTime = 5f;

    bool isExecuting = false;
    public bool startMenu = false;

    void Start ()
    {
        if (startMenu)
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.UnPauseGame ();
            }
            Cursor.lockState = CursorLockMode.None;

        }
    }

    void Update ()
    {
        if (pauseMenu == null)
        {
            return;
        }

        Death ();

        PauseMenu ();
    }

    public void LoadScene (int sceneIndex)
    {
        if (!startMenu)
        {
            if (GameManager.instance.isPaused)
            {
                GameManager.instance.UnPauseGame ();
            }
            else
            {
                return;
            }
        }

        SceneManager.LoadScene (sceneIndex);
    }

    public void PauseMenu ()
    {
        if (Input.GetButtonDown ("Pause"))
        {
            GameManager.instance.isPaused = !GameManager.instance.isPaused;
            pauseMenu.SetActive (GameManager.instance.isPaused);

            if (GameManager.instance.isPaused)
            {
                GameManager.instance.PauseGame ();
            }
            else
            {
                GameManager.instance.UnPauseGame ();
            }
        }
    }

    public void Continue ()
    {
        GameManager.instance.UnPauseGame ();
    }

    public void Death ()
    {
        if (!GameManager.instance.playerAlive && !isExecuting)
        {
            isExecuting = true;
            StartCoroutine (ExecuteDeath ());
        }
    }

    public void ExitGame ()
    {
        Application.Quit ();
}

IEnumerator ExecuteDeath ()
{
    deathScreen.SetActive (true);
    yield return new WaitForSeconds (waitingTime);
    deathScreen.SetActive (false);
    loadingScreen.SetActive (true);

}

}