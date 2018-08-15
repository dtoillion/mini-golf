using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

  public static GameController control;

  public float HoleCount;
  public Text HoleCountText;

  public float StrokeCount;
  public Text StrokeCountText;

  void Awake () {
    if (control == null)
      control = this;
    else if (control != this)
      Destroy(gameObject);
  }

	void Start () {
    HoleCount = 1f;
    HoleCountText.text = "Hole: " + HoleCount;

    StrokeCount = 0f;
    StrokeCountText.text = "Strokes: " + StrokeCount;

	}

	// Update is called once per frame
	void Update () {

	}
}
