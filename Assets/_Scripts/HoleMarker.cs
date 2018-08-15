using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HoleMarker : MonoBehaviour {

  public Text CountDownText;
  private bool BallInCup = false;
  private AudioSource CupAudio;

  void Start () {
    CountDownText.text = "";
    CupAudio = GetComponent<AudioSource>();
  }

  void OnTriggerEnter(Collider c) {
    if(c.gameObject.tag == "GolfBall") {
      BallInCup = true;
      StartCoroutine("CountDown");
    }
  }

  void OnTriggerExit(Collider c) {
    if(c.gameObject.tag == "GolfBall") {
      BallInCup = false;
      StopCoroutine("CountDown");
      CountDownText.text = "";
    }
  }

  IEnumerator CountDown() {
    yield return new WaitForSeconds(1f);
    CountDownText.text = "3";
    yield return new WaitForSeconds(1f);
    CountDownText.text = "2";
    yield return new WaitForSeconds(1f);
    CountDownText.text = "1";
    yield return new WaitForSeconds(1f);
    CountDownText.text = "Ball In!";
    CupAudio.Play();
  }
}
