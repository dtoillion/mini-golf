using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryCreator : MonoBehaviour {

  public GameObject[] Scenery;
  private Vector3 SpawnPosition;

	void Start() {
    SpawnPosition = transform.position;
    Instantiate(Scenery[Random.Range(0, Scenery.Length)], SpawnPosition, Quaternion.identity);
  }

}
