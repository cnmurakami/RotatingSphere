using UnityEngine;
using System.Collections;
using tv.ouya.console.api;

/// <summary>
/// Manages score
/// </summary>
public class Score : MonoBehaviour {
	//Score amount
	public static int score;
	//Current time
	protected float time;
	[Tooltip("Interval to get +1 score")]
	public float interval=0.5f;

	/// <summary>
	/// Initialize the variables at the start of the game
	/// </summary>
	void Start() {
		#if UNITY_ANDROID && !UNITY_EDITOR

		if (OuyaSDK.OuyaInput.IsControllerConnected(0)) {
			interval=interval/OuyaMultiplier.value;
		}

		#endif
		score=0;
		time=Time.time;
	}

	/// <summary>
	/// Adds 1 to score count every half second (based on TimeScale)
	/// </summary>
	void FixedUpdate() {
		if (Time.time-time>=interval) {
			score+=1;
			time=Time.time;
		}
	}
}
