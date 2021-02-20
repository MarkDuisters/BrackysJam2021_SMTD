using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameState
{

    public bool isPaused { get; set; }

    static public GameManager instance;

    public int maxCreatures = 40;

    [HideInInspector] public int creatureCount = 1;
    [HideInInspector] public bool playerAlive = true;

    void Start ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy (gameObject);
        }
        DissableMouse ();
    }
    public void PauseGame ()
    {
        EnableMouse ();
        isPaused = true;
        Time.timeScale = 0.00001f;
    }
    public void UnPauseGame ()
    {
        DissableMouse ();
        isPaused = false;
        Time.timeScale = 1;

    }

    public void ExitGame ()
    {
        Application.Quit ();
    }

    public void EnableMouse ()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void DissableMouse ()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
}