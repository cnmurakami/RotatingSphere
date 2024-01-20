using UnityEngine;
using System.Collections;

/// <summary>
/// Hides cursor while game is played
/// </summary>
public class HideCursor : MonoBehaviour {
	public bool hideCursor;

	/// <summary>
	/// Checks if the game is paused to toggle mouse visibility
	/// </summary>
	void Update() {
		Cursor.lockState=CursorLockMode.None;
		if (Pause.isPaused==false) {
			Cursor.visible=!hideCursor;
			if (hideCursor) {
				Cursor.lockState=CursorLockMode.Locked;
			}
		}
		else {
			Cursor.visible=true;
		}
	}
}
