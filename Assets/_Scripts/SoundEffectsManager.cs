using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
  AudioSource audioSrc;
  public AudioClip[] audioClips;
  public static SoundEffectsManager soundControl;

  void Start()
  {
    soundControl = this;
    audioSrc = GetComponent<AudioSource>();
  }

  public void BallHitsObject () {
    audioSrc.clip = audioClips[0];
    audioSrc.pitch = (Random.Range(0.6f, 1.2f));
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }

  public void PlayerMouseDown () {
    audioSrc.clip = audioClips[1];
    audioSrc.pitch = (Random.Range(0.6f, 1.2f));
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }

  public void PlayerMouseUp () {
    audioSrc.clip = audioClips[2];
    audioSrc.pitch = (Random.Range(0.6f, 1.2f));
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }

  public void BallHitsFlagPole () {
    audioSrc.clip = audioClips[3];
    audioSrc.pitch = (Random.Range(0.6f, 1.2f));
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }

  public void BallHitsFlagPoleHard () {
    audioSrc.clip = audioClips[4];
    audioSrc.pitch = (Random.Range(0.6f, 1.2f));
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }

  public void BallGoesInCup () {
    audioSrc.clip = audioClips[5];
    audioSrc.pitch = (Random.Range(0.6f, 1.2f));
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }

}
