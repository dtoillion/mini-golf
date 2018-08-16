using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour {

  void Update() {
    if (Input.anyKey)
      StartGame ();
  }

	public void StartGame() {
    SceneManager.LoadScene("Course 01");
  }

}
