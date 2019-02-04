using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {

  public static MainMenu control;
  public Toggle SinglePlayerMode;

  void Awake() {
    if (control == null) {
      DontDestroyOnLoad(this.gameObject);
      control = this;
    } else if (control != this) {
      Destroy(gameObject);
    }
  }

  public void StartGame() {
    SceneManager.LoadScene("GameScene");
    if(!SinglePlayerMode.isOn)
      GameController.control.SinglePlayer = false;
  }

}
