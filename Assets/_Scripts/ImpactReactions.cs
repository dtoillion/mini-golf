using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ImpactReactions : MonoBehaviour
{
  private bool Impact;
  private Rigidbody rb;

  void Awake () {
    rb = GetComponent<Rigidbody>();
  }

  void OnCollisionEnter(Collision col) {
    if((!Impact) && (col.relativeVelocity.magnitude > 8)) {
      Impact = true;
      rb.isKinematic = false;
      SoundEffectsManager.soundControl.BallHitsFlagPoleHard();
      rb.AddForce(30f, 0, 0);
      rb.AddTorque(transform.up * 1000f * 360f);
    } else if (col.relativeVelocity.magnitude > 3) {
      SoundEffectsManager.soundControl.BallHitsFlagPole();
    }
  }
}
