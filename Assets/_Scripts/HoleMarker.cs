using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HoleMarker : MonoBehaviour {

  private Light HoleMarkerLight;

  void Start() {
    GameController.control.NotificationText.text = "";
    HoleMarkerLight = GetComponent<Light>();
  }

  void OnTriggerEnter(Collider c) {
    if(c.gameObject.tag == "GolfBall") {
      StartCoroutine("CountDown");
      CameraShake.Shake(0.3f, 0.3f);
      SoundEffectsManager.soundControl.BallGoesInCup();
      HoleMarkerLight.intensity = 3f;
    }

  }

  void OnTriggerExit(Collider c) {
    if(c.gameObject.tag == "GolfBall") {
      StopCoroutine("CountDown");
      GameController.control.NotificationText.text = "";
      HoleMarkerLight.intensity = 0.3f;
    }
  }

  IEnumerator CountDown() {
    yield return new WaitForSeconds(0.5f);
    GameController.control.NotificationText.text = "3";
    yield return new WaitForSeconds(0.5f);
    GameController.control.NotificationText.text = "2";
    yield return new WaitForSeconds(0.5f);
    GameController.control.NotificationText.text = "1";
    yield return new WaitForSeconds(0.5f);
    GameController.control.NotificationText.text = "Ball In!";
    yield return new WaitForSeconds(1f);
    GameController.control.SetUpCourse();
  }

}
