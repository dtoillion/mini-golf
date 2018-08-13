using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour {

  private Rigidbody rb;
  private Vector3 startPosition;
  private Vector3 stopPosition;
  private Vector3 aimDirection;

	void Awake ()
  {
    rb = GetComponent<Rigidbody>();
	}

  void OnMouseDown ()
  {
    startPosition = Input.mousePosition;
    Debug.Log(startPosition);
  }

  void OnMouseUp ()
  {
    stopPosition = Input.mousePosition;

    aimDirection = startPosition - stopPosition;
    aimDirection.Normalize();
    rb.AddForce(aimDirection * 100f);

    Debug.Log(aimDirection);
  }

}
