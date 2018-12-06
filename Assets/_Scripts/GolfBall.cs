using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour {

  public AudioClip[] BallAudioClips;
  public float ForcePower;

  private Light GolfBallLight;
  private AudioSource BallAudio;
  private Rigidbody rb;
  private Vector3 startPosition;
  private Vector3 stopPosition;
  private Vector3 aimDirection;

	void Awake() {
    rb = GetComponent<Rigidbody>();
    BallAudio = GetComponent<AudioSource>();
    GolfBallLight = GetComponent<Light>();
	}

  void OnCollisionEnter(Collision col) {
    BallAudio.clip = BallAudioClips[2];
    if(!BallAudio.isPlaying)
    {
      BallAudio.Play();
    }
  }

  void OnMouseDown() {
    startPosition = Input.mousePosition;
    // Debug.Log("Start:" + startPosition);
    GolfBallLight.intensity = 0.5f;
    BallAudio.clip = BallAudioClips[0];
    BallAudio.Play();
  }

  void OnMouseUp() {
    stopPosition = Input.mousePosition;
    // Debug.Log("Stop:" + stopPosition);
    GolfBallLight.intensity = 1f;
    BallAudio.clip = BallAudioClips[1];
    BallAudio.Play();

    aimDirection = Camera.main.ViewportToWorldPoint(new Vector3(startPosition.x - stopPosition.x, startPosition.y - stopPosition.y, startPosition.z - stopPosition.z));
    aimDirection = aimDirection / 3;
    rb.AddForce(aimDirection.x, 0f, aimDirection.z);
    // Debug.Log("Force:" + aimDirection);

    GameController.control.StrokeCount += 1f;
    GameController.control.StrokeCountText.text = "Stoke: " + GameController.control.StrokeCount;
  }

}
