using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using tv.ouya.console.api;

/// <summary>
/// Sets the duration of the Power after it is aquired
/// </summary>
public class PowerTimer : MonoBehaviour {
	[Tooltip("How long the power will last (in frames)")]
	public float duration=600f;
	protected float time;
	[Tooltip("Slider indicating the timer (should be child of the power activator")]
	public Image timerSlider;

	/// <summary>
	/// Sets initial time and values of the slider
	/// </summary>
	void Start() {
		#if UNITY_ANDROID && !UNITY_EDITOR

		if (OuyaSDK.OuyaInput.IsControllerConnected(0)) {
		duration=duration/OuyaMultiplier.value;
		}

		#endif
		time=0;
		timerSlider.fillAmount=1;
	}

	/// <summary>
	/// Updates the slider and checks wheter it has to be destroyed based on time lapsed
	/// </summary>
	void Update() {
		timerSlider.fillAmount=1-(time/duration);
		if (Pause.isPaused==false) {
			if (time<=duration) {
				time++;
			}
			else {
				Destroy(this.gameObject);
			}
		}
	}
}
