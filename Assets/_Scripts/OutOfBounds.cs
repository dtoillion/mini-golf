using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

  private GameObject ObjectToDelete;
  private AudioSource BallOutOfBoundsAudio;
  private bool BallOut = false;

  void Awake() {
    BallOutOfBoundsAudio = GetComponent<AudioSource>();
  }

  void OnCollisionEnter(Collision col) {
    if((col.gameObject.tag == "GolfBall") && (!BallOut)) {
      BallOut = true;
      StartCoroutine("BallOutOfBounds");
    }
  }
  IEnumerator BallOutOfBounds() {
    GameController.control.NotificationText.text = "Out of bounds!";
    BallOutOfBoundsAudio.Play();
    yield return new WaitForSeconds(1f);
    GameController.control.ResetBall();
    GameController.control.NotificationText.text = "";
    BallOut = false;
    StopCoroutine("BallOutOfBounds");
  }
}
