using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Displays player current Score while in game.
/// </summary>
public class ShowScore : MonoBehaviour {
	[Tooltip("Text do display Score")]
	public Text scoreboard;


	void Start() {
		scoreboard.text="Score: "+Score.score.ToString();
	}

	void Update() {
		scoreboard.text="Score: "+Score.score.ToString();
	}
}
