using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

  public static GameController control;

  AudioSource MenuAudioSource;

  private GameObject ObjectToDelete;
  private int CurrentTurnStrokeCount;
  private Vector3 HolePosition;
  private Vector3 SpawnPosition;

  public bool SinglePlayer = false;
  public bool SpawnHole = true;

  public float StrokeCount2P;
  public float StrokeCount;

  public GameObject GolfBall2P;
  public GameObject GolfBall;
  public GameObject MainMenuScreen;
  public GameObject[] Holes;

  public int HoleCount;

  public Text HoleCountText;
  public Text NotificationText;
  public Text StrokeCountText2P;
  public Text StrokeCountText;

  void Awake() {
    if (control == null)
      control = this;
    else if (control != this)
      Destroy(gameObject);

    MenuAudioSource = GetComponent<AudioSource>();

  }

	void Start() {
    HoleCountText.text = "Hole: " + (HoleCount + 1) + " of 9";
    NotificationText.text = "Player 1 Go!";
    NotificationText.color = new Color32(9, 132, 227, 255);
    // NotificationText.color = new Color32(194, 54, 22, 255);
    StrokeCount = 0f;
    StrokeCountText.text = "P1: " + StrokeCount;
    StrokeCount2P = 0f;
    StrokeCountText2P.text = "P2: " + StrokeCount2P;

    HolePosition = transform.position;
    if(SpawnHole)
      Instantiate(Holes[HoleCount], HolePosition, transform.rotation);

    SpawnPosition = new Vector3(0, 3f, 0);
    Instantiate(GolfBall, SpawnPosition, Quaternion.identity);
  }

  public void SetUpCourse() {

    if(HoleCount < Holes.Length - 1)
    {
      HoleCount += 1;

      // Destroy existing ball and hole
      ObjectToDelete = GameObject.FindWithTag("GolfBall");
      Destroy(ObjectToDelete);

      ObjectToDelete = GameObject.FindWithTag("Hole");
      Destroy(ObjectToDelete);

      // Increase the hole count and update the text
      HoleCountText.text = "Hole: " + (HoleCount + 1) + " of 9";

      // Spawn the new hole and ball
      Instantiate(Holes[HoleCount], HolePosition, transform.rotation);
      Instantiate(GolfBall, SpawnPosition, Quaternion.identity);
    } else {
      NotificationText.text = "You Win!";
    }

  }

  // Menu stuff
  // Main Menu and Players selection

  public void PlayMenuSound() {
    MenuAudioSource.Play();
  }

  public void ToggleMainMenu() {
    PlayMenuSound();
    if(MainMenuScreen.activeSelf)
      MainMenuScreen.SetActive(false);
    else
      MainMenuScreen.SetActive(true);
  }

  public void ResetGame() {
    PlayMenuSound();
    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
  }

  public void ResetBall() {
    PlayMenuSound();
    if(MainMenuScreen.activeSelf)
      ToggleMainMenu();
    ObjectToDelete = GameObject.FindWithTag("GolfBall");
    Destroy(ObjectToDelete);
    Instantiate(GolfBall, SpawnPosition, Quaternion.identity);
  }

}
