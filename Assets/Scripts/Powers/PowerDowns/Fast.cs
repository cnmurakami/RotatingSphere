using UnityEngine;
using System.Collections;

/// <summary>
/// Speeds up the game;
/// </summary>
public class Fast : MonoBehaviour {
	[Tooltip("How much speed will be increased")]
	public float factor=0.5f;

	/// <summary>
	/// Increment speed by factor
	/// </summary>
	void Start() {
		Time.timeScale+=factor;
		GameObject.Find("TimeFlowController").GetComponent<TimeFlow>().startTime=Time.time;
	}
	
	// Update is called once per frame
	void Update() {
		Destroy(this.gameObject);
	}
}
