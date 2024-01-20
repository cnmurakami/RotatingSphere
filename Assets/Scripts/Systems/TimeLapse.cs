using UnityEngine;
using System.Collections;
using tv.ouya.console.api;

/// <summary>
/// Rotates the sun directional light to create a illusion of passing time
/// </summary>
public class TimeLapse : MonoBehaviour {
	[Tooltip("Speed to rotate the sun at X axis")]
	public float speedX;
	[Tooltip("Speed to rotate the sun at Y axis (should be considerably smaller than Speed X")]
	public float speedY;
	[Tooltip("Sun Directional Light")]
	public Light sun;
	[Tooltip("Stars Particle System")]
	public GameObject stars;

	void Start() {
		#if UNITY_ANDROID && !UNITY_EDITOR

		if (OuyaSDK.OuyaInput.IsControllerConnected(0)) {
			speedX=speedX/OuyaMultiplier.value;
			speedY=speedY/OuyaMultiplier.value;
		}

		#endif
	}

	/// <summary>
	/// Rotates the sun at desired speeds
	/// </summary>
	void Update() {
		if (Pause.isPaused==false) {
			sun.transform.Rotate(speedX, speedY, 0);
			stars.transform.Rotate(speedX, 0, 0);
		}
	}
}
