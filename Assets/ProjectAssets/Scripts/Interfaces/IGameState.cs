using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameState
{

  public bool isPaused { get; set; }

  void PauseGame ();
  void UnPauseGame ();

  void ExitGame ();
  void EnableMouse ();
  void DissableMouse ();
}