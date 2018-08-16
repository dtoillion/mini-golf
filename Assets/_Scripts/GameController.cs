using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

  public static GameController control;

  public GameObject GolfBall;
  private Vector3 SpawnPosition;

  public GameObject[] Holes;
  private GameObject ObjectToDelete;
  private Vector3 HolePosition;

  public int HoleCount;
  public Text HoleCountText;

  public Text NotificationText;

  public float StrokeCount;
  public Text StrokeCountText;

  void Awake () {
    if (control == null)
      control = this;
    else if (control != this)
      Destroy(gameObject);
  }

	void Start () {
    HoleCount = 0;
    HoleCountText.text = "Hole: " + (HoleCount + 1);

    StrokeCount = 0f;
    StrokeCountText.text = "Strokes: " + StrokeCount;

    HolePosition = transform.position;
    Instantiate(Holes[HoleCount], HolePosition, transform.rotation);

    SpawnPosition = new Vector3(0, 3f, 0);
    Instantiate(GolfBall, SpawnPosition, Quaternion.identity);
  }

  public void SetUpCourse () {
    // Destroy existing ball and hole
    ObjectToDelete = GameObject.FindWithTag("GolfBall");
    Destroy(ObjectToDelete);
    ObjectToDelete = GameObject.FindWithTag("Hole");
    Destroy(ObjectToDelete);

    // Increase the hole count and update the text
    HoleCount += 1;
    HoleCountText.text = "Hole: " + (HoleCount + 1);

    // Spawn the new hole and ball
    Instantiate(Holes[HoleCount], HolePosition, transform.rotation);
    Instantiate(GolfBall, SpawnPosition, Quaternion.identity);
  }

  public void ResetBall () {
    ObjectToDelete = GameObject.FindWithTag("GolfBall");
    Destroy(ObjectToDelete);
    Instantiate(GolfBall, SpawnPosition, Quaternion.identity);
  }

  public void ResetGame () {
    SceneManager.LoadScene("Course 01");
  }

}
