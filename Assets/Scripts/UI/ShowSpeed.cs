using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Display current TimeScale as Orb speed while in game
/// </summary>
public class ShowSpeed : MonoBehaviour {
	[Tooltip("Text do display Speed")]
	public Text speed;
	[Tooltip("Fictional Unit speed to be used")]
	public string speedUnit;

	void Start() {
		speed.text="Orb Speed: "+Time.timeScale.ToString("F2")+speedUnit.ToString();
	}

	/// <summary>
	/// Only updates the score if it's not paused
	/// </summary>
	void Update() {
		if (Time.timeScale!=0) {
			speed.text="Orb Speed: "+Time.timeScale.ToString("F2")+speedUnit.ToString();
		}
	}
}
