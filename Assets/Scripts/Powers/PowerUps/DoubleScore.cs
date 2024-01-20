using UnityEngine;
using System.Collections;

/// <summary>
/// Doubles score gain while active by repeating Score gain
/// </summary>
public class DoubleScore : MonoBehaviour {
	//Current time
	protected float time;
	protected float interval;

	/// <summary>
	/// Initializing variables
	/// </summary>
	void Start() {
		interval=GameObject.Find("Score").GetComponent<Score>().interval;
		time=Time.time;
	}

	/// <summary>
	/// Adds 1 to score count every half second (based on TimeScale)
	/// </summary>
	void FixedUpdate() {
		if (Time.time-time>=interval) {
			Score.score+=1;
			time=Time.time;
		}
	}
}
