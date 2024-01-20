using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Prevents damage while active
/// </summary>
public class Shield : MonoBehaviour {
	protected GameObject health;

	// Use this for initialization
	void Start() {
		health=GameObject.Find("Health");
	}

	/// <summary>
	/// Disables damage calculation
	/// </summary>
	void Update() {
		health.GetComponent<Health>().isReceivingDamage=false;
	}
}
