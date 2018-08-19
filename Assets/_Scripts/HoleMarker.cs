﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HoleMarker : MonoBehaviour {

  private AudioSource CupAudio;
  private Light HoleMarkerLight;

  void Awake() {
    GameController.control.NotificationText.text = "";
    CupAudio = GetComponent<AudioSource>();
    HoleMarkerLight = GetComponent<Light>();
  }

  void OnTriggerEnter(Collider c) {
    if(c.gameObject.tag == "GolfBall") {
      StartCoroutine("CountDown");
      HoleMarkerLight.intensity = 4f;
    }

  }

  void OnTriggerExit(Collider c) {
    if(c.gameObject.tag == "GolfBall") {
      StopCoroutine("CountDown");
      GameController.control.NotificationText.text = "";
      HoleMarkerLight.intensity = 1f;
    }
  }

  IEnumerator CountDown() {
    yield return new WaitForSeconds(0.5f);
    GameController.control.NotificationText.text = "3";
    CupAudio.Play();
    yield return new WaitForSeconds(0.5f);
    GameController.control.NotificationText.text = "2";
    yield return new WaitForSeconds(0.5f);
    GameController.control.NotificationText.text = "1";
    yield return new WaitForSeconds(0.5f);
    GameController.control.NotificationText.text = "Ball In!";
    HoleMarkerLight.intensity = 5f;
    yield return new WaitForSeconds(1f);

    GameController.control.SetUpCourse();

  }

}
