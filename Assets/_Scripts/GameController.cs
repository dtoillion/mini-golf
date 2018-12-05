using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

  public static GameController control;
  public bool SpawnHole = true;

  public GameObject GolfBall;
  private Vector3 SpawnPosition;

  public GameObject[] Holes;
  private GameObject ObjectToDelete;
  private Vector3 HolePosition;

  private int HoleCount;
  public Text HoleCountText;

  public Text NotificationText;

  public float StrokeCount;
  public Text StrokeCountText;

  void Awake() {
    if (control == null)
      control = this;
    else if (control != this)
      Destroy(gameObject);
  }

	void Start() {
    HoleCountText.text = "Hole: " + (HoleCount + 1) + " of 9";

    StrokeCount = 0f;
    StrokeCountText.text = "Strokes: " + StrokeCount;

    HolePosition = transform.position;
    if(SpawnHole)
      Instantiate(Holes[HoleCount], HolePosition, transform.rotation);

    SpawnPosition = new Vector3(0, 3f, 0);
    Instantiate(GolfBall, SpawnPosition, Quaternion.identity);
  }

  public void SetUpCourse() {
    // Destroy existing ball and hole
    ObjectToDelete = GameObject.FindWithTag("GolfBall");
    Destroy(ObjectToDelete);

    HoleCount += 1;

    if(HoleCount < 9)
    {
      ObjectToDelete = GameObject.FindWithTag("Hole");
      Destroy(ObjectToDelete);

      // Increase the hole count and update the text
      HoleCountText.text = "Hole: " + (HoleCount + 1) + " of 9";

      // Spawn the new hole and ball
      Instantiate(Holes[HoleCount], HolePosition, transform.rotation);
      Instantiate(GolfBall, SpawnPosition, Quaternion.identity);
    }

  }

  public void ReturnToMainMenu() {
    SceneManager.LoadScene("MainMenu");
  }

  public void ResetGame() {
    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
  }

  public void ResetBall() {
    ObjectToDelete = GameObject.FindWithTag("GolfBall");
    Destroy(ObjectToDelete);
    Instantiate(GolfBall, SpawnPosition, Quaternion.identity);
  }

}
