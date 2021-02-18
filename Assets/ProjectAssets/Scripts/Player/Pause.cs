using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour, IGameState
{

    [SerializeField] bool getIsPaused;
    public bool isPaused { get; set; }

    void Start ()
    {
        DissableMouse ();
    }
    public void PauseGame ()
    {
        EnableMouse ();
        isPaused = true;
        getIsPaused = isPaused;
    }
    public void UnPauseGame ()
    {
        DissableMouse ();
        isPaused = false;
        getIsPaused = isPaused;

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