using UnityEngine;
using System.Collections;

/// <summary>
/// Slows down the game on activation
/// </summary>
public class Slow : MonoBehaviour {
	[Tooltip("How much speed will be decreased")]
	public float factor=0.5f;
	// Use this for initialization
	void Start() {
		Time.timeScale-=factor;
		GameObject.Find("TimeFlowController").GetComponent<TimeFlow>().startTime=Time.time;
	}
	
	// Update is called once per frame
	void Update() {
		if (Time.timeScale<1-factor) {
			Time.timeScale=1-factor;
		}
		Destroy(this.gameObject);
	}
}
