using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
  public GameObject ObjectToTarget;
  
  void Update()
  {
    ObjectToTarget = GameObject.FindWithTag("GolfBall");  
    transform.position = ObjectToTarget.transform.position;
  }

}
