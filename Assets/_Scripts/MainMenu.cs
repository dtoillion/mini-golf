using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {

  public Toggle SinglePlayerMode;
  public bool SinglePlayerModeOn;

  public void StartGame() {
    if(!SinglePlayerMode.isOn)
      SinglePlayerModeOn = false;
    else
      SinglePlayerModeOn = true;
    SceneManager.LoadScene("GameScene");
  }

}
