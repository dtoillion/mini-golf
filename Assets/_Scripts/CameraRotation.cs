using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

  void Update() {
    if(Input.GetKeyDown("space")) {
      RotateCamera();
    }
  }

  void RotateCamera() {
    Debug.Log("space pressed");
    transform.rotation = transform.rotation * Quaternion.Euler(0, 90.0f, 0);
  }

}
