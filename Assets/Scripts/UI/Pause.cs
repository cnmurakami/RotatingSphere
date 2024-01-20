using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using tv.ouya.console.api;

/// <summary>
/// Pauses the game
/// </summary>
public class Pause : MonoBehaviour {
	public Canvas pauseScreen;
	public Button resume;
	public static bool isPaused;
	protected float currentTime;

	void Start() {
		isPaused=false;
		pauseScreen.gameObject.SetActive(false);
	}

	/// <summary>
	/// Activates PauseGame function when key is pressed
	/// </summary>
	void Update() {
		if (Input.GetButtonDown("Cancel")) {
			PauseGame();
		}
		#if UNITY_ANDROID && !UNITY_EDITOR

		if (OuyaSDK.OuyaInput.IsControllerConnected(0)) {
			var button_Y = OuyaSDK.OuyaInput.GetButtonDown(0, OuyaController.BUTTON_Y);
			if (button_Y){
				PauseGame();
			}
		}

		#endif
	}

	/// <summary>
	/// When activated, Pause stores current TimeScale and changes TimeScale to 0
	/// When deactivated, Pause restores current TimeScale
	/// </summary>
	public void PauseGame() {
		if (isPaused==false) {
			currentTime=Time.timeScale;
			Time.timeScale=0;
			//print("PAUSED");
			isPaused=true;
			pauseScreen.gameObject.SetActive(true);
			resume.Select();
		}
		else {
			Time.timeScale=currentTime;
			//print("RESUME");
			isPaused=false;
			pauseScreen.gameObject.SetActive(false);
		}
	}

	/// <summary>
	/// Goes to Title screen
	/// </summary>
	public void TitleScreen() {
		SceneManager.LoadScene("TitleScreen");
	}
}
