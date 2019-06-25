using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour {

  private Rigidbody rb;
  private Vector3 startPosition;
  private Vector3 stopPosition;
  private Vector3 aimDirection;
  private Light GolfBallLight;

  private bool GrabbedOn = false;

	void Awake() {
    rb = GetComponent<Rigidbody>();
    GolfBallLight = GetComponent<Light>();
    GolfBallLight.intensity = 0f;
	}

  void OnCollisionEnter(Collision col) {
    SoundEffectsManager.soundControl.BallHitsObject();
  }

  void OnMouseExit() {
    if(!GrabbedOn)
      GolfBallLight.intensity = 0f;
  }

  void OnMouseOver() {
    if(!GrabbedOn)
      GolfBallLight.intensity = 2f;
  }

  void OnMouseDown() {
    GrabbedOn = true;
    GolfBallLight.intensity = 1f;
    startPosition = Input.mousePosition;
    SoundEffectsManager.soundControl.PlayerMouseDown();
  }

  void OnMouseUp() {
    GrabbedOn = false;
    GolfBallLight.intensity = 0f;
    stopPosition = Input.mousePosition;
    SoundEffectsManager.soundControl.PlayerMouseUp();

    aimDirection = Camera.main.ScreenToViewportPoint(new Vector3(startPosition.x - stopPosition.x, startPosition.y - stopPosition.y, startPosition.z - stopPosition.z));
    aimDirection = new Vector3(aimDirection.x, aimDirection.y, aimDirection.z) * 10000;
    rb.AddForce(aimDirection.x, 0f, aimDirection.y);

    GameController.control.StrokeCount += 1f;
    GameController.control.StrokeCountText.text = "Stoke: " + GameController.control.StrokeCount;
  }

}
