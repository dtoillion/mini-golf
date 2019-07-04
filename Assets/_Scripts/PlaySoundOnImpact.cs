using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnImpact : MonoBehaviour {

  private AudioSource ImpactAudio;
  public bool RandomizePitch;

	void Awake () {
    ImpactAudio = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision col) {
    if(!ImpactAudio.isPlaying) {
      ImpactAudio.pitch = (Random.Range(0.6f, 1.2f));
      ImpactAudio.Play();
    }
  }
}
