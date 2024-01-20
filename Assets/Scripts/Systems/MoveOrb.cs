using UnityEngine;
using System.Collections;

/// <summary>
/// Randomly moves the Orb around the Globe surface
/// </summary>
public class MoveOrb : MonoBehaviour {
	[Tooltip("Orb base speed (will be increased by TimeScale")]
	public float speed=0.25f;
	[Tooltip("Minimum amount of time to change direction (will be affected by TimeScale)")]
	public int minRange=200;
	[Tooltip("Maximum amount of time to change direction (will be affected by TimeScale)")]
	public int maxRange=300;
	//timer= result from Random between min and max Range;
	protected int timer;
	//time= time passed since last timer calc;
	protected int time;
	//axis= new direction for the Orb;
	protected Vector3 axis;

	/// <summary>
	/// Generating first timer and first direction
	/// </summary>
	void Start() {
		NewDirection();
	}

	/// <summary>
	/// At each interval based on TimeScale, time is added, and then checked if it reached timer limit
	/// Higher TimeScale means faster time addition;
	/// </summary>
	void FixedUpdate() {
		if (Pause.isPaused==false) {
			this.transform.Rotate(axis);
			time++;
			if (time>=timer) {
				NewDirection();
			}
		}
	}

	/// <summary>
	/// Generates a new timer and new direction
	/// </summary>
	void NewDirection() {
		timer=Random.Range(minRange, maxRange);
		time=0;
		//Axis get a Random Range (0, 2)*2-1 to always return -1 or 1, then it's multiplied to TimeScale and base speed
		axis=new Vector3((Random.Range(0, 2)*2-1)*Time.timeScale*speed, (Random.Range(0, 2)*2-1)*Time.timeScale*speed, (Random.Range(0, 2)*2-1)*Time.timeScale*speed);
	}
}
