using UnityEngine;
using System.Collections;

/// <summary>
/// Controls TimeScale to increase game speed over time
/// </summary>
public class TimeFlow : MonoBehaviour {
	[Tooltip("Initial time to wait before increasing TimeScale at game start")]
	public float secondsToWait=10f;
	[Tooltip("Amount of TimeScale to be increased by each update")]
	public float step=0.00001f;
	//Stores game start time
	public float startTime;

	/// <summary>
	/// Sets initial timeScale and start time
	/// </summary>
	void Start() {
		Time.timeScale=1f;
		startTime=Time.time;
	}

	/// <summary>
	/// Each update increases TimeScale by step amount after wait time has expired
	/// </summary>
	void Update() {
		if (Pause.isPaused==false) {
			if (Time.time-startTime>secondsToWait) {
				Time.timeScale+=step;
			}
		}
	}
}
