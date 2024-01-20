using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manages screens and screen buttons
/// </summary>
public class ScreenManager : MonoBehaviour {
	[Tooltip("Title screen Canvas")]
	public Canvas title;
	[Tooltip("Option screen Canvas")]
	public Canvas options;
	public Button btn;

	/// <summary>
	/// Starts with the title screen enabled
	/// </summary>
	void Start() {
		title.gameObject.SetActive(true);
		options.gameObject.SetActive(false);
	}

	/// <summary>
	/// Starts the game
	/// </summary>
	public void StartGame() {
		SceneManager.LoadScene("MainStage");
	}

	/// <summary>
	/// Quits application
	/// </summary>
	public void Quit() {
		Application.Quit();
	}

	/// <summary>
	/// Goes to title screen
	/// </summary>
	public void TitleScreen() {
		SceneManager.LoadScene("TitleScreen");
	}

	/// <summary>
	/// Goes to option screen
	/// </summary>
	public void Options() {
		title.gameObject.SetActive(false);
		options.gameObject.SetActive(true);
		btn.Select();
	}
}
