using UnityEngine;
using System.Collections;

/// <summary>
/// Generates random position around the Globe while no power is spawned
/// </summary>
public class RandomRotation : MonoBehaviour {

	/// <summary>
	/// Keeps rotating randomly while no Power is present
	/// </summary>
	void Update() {
		if (!GameObject.FindGameObjectWithTag("Power")) {
			this.transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		}
	}
}
