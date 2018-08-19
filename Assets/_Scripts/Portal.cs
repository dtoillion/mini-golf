using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	void Awake () {
		transform.position = new Vector3(transform.position.x, -0.6f, transform.position.z);
	}

	void Update () {
		// if(GameController.control.HoleCount >= 0) {
		// 	Debug.Log(GameController.control.HoleCount);
		// }
	}

	
}
