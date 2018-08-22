using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour {

  public void StartKenneyJamGame() {
    SceneManager.LoadScene("Kenneyjam");
  }

  public void StartSpaceCourseGame() {
    SceneManager.LoadScene("SpaceCourse");
  }

}
