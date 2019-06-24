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
    if(!Impact) {
      Debug.Log("impact");
      Impact = true;
      rb.isKinematic = false;
      rb.AddForce(30f, 0, 0);
    }
  }
}
