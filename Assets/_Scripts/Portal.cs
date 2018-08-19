using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {


  public GameObject Alien;
  public float SpawnRate;
  private Vector3 CenterPortal;
  private bool HasSpewn = false;
  private AudioSource PortalAudio;

  void Start () {
    PortalAudio = GetComponent<AudioSource>();
    CenterPortal = new Vector3(transform.position.x + 0.5f, transform.position.y + 1.5f, transform.position.z + 0.5f);
  }

  void Update () {
    if((!HasSpewn) && (GameController.control.HoleCount == 9))
    {
      HasSpewn = true;
      GameController.control.NotificationText.text = "You Did It!";
      PortalAudio.Play();
      StartCoroutine("SpewAliens");
    }
  }

  IEnumerator SpewAliens () {
    for (int i = 1; i < 10; i++)
    {
      Instantiate(Alien, CenterPortal, transform.rotation);
      yield return new WaitForSeconds (SpawnRate);
    }
  }
}
