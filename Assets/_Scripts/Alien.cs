using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

  private Rigidbody rb;
  private float ForcePower;

	void Start () {
    rb = GetComponent<Rigidbody>();

    ForcePower = Random.Range(75f, 150f);
    rb.AddForce(0, 0, transform.position.z * -ForcePower);
	}
}
