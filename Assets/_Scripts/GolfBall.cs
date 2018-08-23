﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour {

  public float ForcePower = 10f;
  public float ForcePowerLimit = 12f;
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

  void Update() {
    if(rb.velocity.magnitude > ForcePowerLimit){
      rb.velocity = Vector3.ClampMagnitude(rb.velocity, ForcePowerLimit);
    }
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
    GolfBallLight.intensity = 0.5f;
    BallAudio.clip = BallAudioClips[0];
    BallAudio.Play();
  }

  void OnMouseUp() {
    stopPosition = Input.mousePosition;
    GolfBallLight.intensity = 1f;
    BallAudio.clip = BallAudioClips[1];
    BallAudio.Play();
    aimDirection = new Vector3(startPosition.x - stopPosition.x, 0, startPosition.y - stopPosition.y);
    rb.AddForce(aimDirection.x * ForcePower, 0, aimDirection.z * ForcePower);
    GameController.control.StrokeCount += 1f;
    GameController.control.StrokeCountText.text = "Stoke: " + GameController.control.StrokeCount;
  }

}
