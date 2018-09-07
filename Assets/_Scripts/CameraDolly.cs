using UnityEngine;
using System.Collections;

public class CameraDolly : MonoBehaviour {

  public float CameraSpeed = 3f;
  private float XInputValue;
  private float YInputValue;
  private Rigidbody rb;

  void Awake() {
    rb = GetComponent<Rigidbody>();
  }

  void Update() {
    XInputValue = Input.GetAxis("Horizontal");
    YInputValue = Input.GetAxis("Vertical");

    if(Input.GetKeyDown("space")) {
      RotateCamera();
    }
  }

  void FixedUpdate() {
    if(XInputValue != 0) {
      MoveCamera();
    }
    if(YInputValue != 0) {
      MoveCamera();
    }
  }

  void MoveCamera() {
    rb.AddForce(transform.forward * YInputValue * CameraSpeed);
    rb.AddForce(transform.right * XInputValue * CameraSpeed);
  }

  void RotateCamera() {
    transform.rotation = transform.rotation * Quaternion.Euler(0, 90.0f, 0);
  }

}
