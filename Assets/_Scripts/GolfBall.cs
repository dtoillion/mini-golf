using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour {

  public float ForcePower = 10f;

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
    Debug.Log(stopPosition);

    aimDirection = new Vector3(startPosition.x - stopPosition.x, 0, startPosition.y - stopPosition.y);

    Debug.Log("Force to ball:" + aimDirection * ForcePower);
    rb.AddForce(aimDirection.x * ForcePower, 0, aimDirection.z * ForcePower);
  }

}
