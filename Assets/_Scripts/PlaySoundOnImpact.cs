using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnImpact : MonoBehaviour {

  private AudioSource ImpactAudio;

	void Awake () {
    ImpactAudio = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision col) {
    if(!ImpactAudio.isPlaying) {
      ImpactAudio.Play();
    }
  }
}
