using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour, IGameState
{

    public bool isPaused { get; set; }

    static public Pause pauseInstance;

    void Start ()
    {
        if (pauseInstance == null)
        {
            pauseInstance = this;
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
    }
    public void UnPauseGame ()
    {
        DissableMouse ();
        isPaused = false;

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