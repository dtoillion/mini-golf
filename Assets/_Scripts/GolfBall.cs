﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour {

  public AudioClip[] BallAudioClips;
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
    GolfBallLight.intensity = 0.6f;
    BallAudio.clip = BallAudioClips[0];
    BallAudio.Play();
  }

  void OnMouseUp() {
    stopPosition = Input.mousePosition;
    GolfBallLight.intensity = 0.3f;
    BallAudio.clip = BallAudioClips[1];
    BallAudio.Play();

    aimDirection = Camera.main.ScreenToViewportPoint(new Vector3(startPosition.x - stopPosition.x, startPosition.y - stopPosition.y, startPosition.z - stopPosition.z));
    Debug.Log(aimDirection);
    aimDirection = new Vector3(aimDirection.x, aimDirection.y, aimDirection.z) * 10000;
    Debug.Log(aimDirection);
    rb.AddForce(aimDirection.x, 0f, aimDirection.y);

    GameController.control.StrokeCount += 1f;
    GameController.control.StrokeCountText.text = "Stoke: " + GameController.control.StrokeCount;
  }

}
