using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Reverses the observation damage and heal while active
/// </summary>
public class Reverse : MonoBehaviour {
	protected GameObject health;

	// Use this for initialization
	void Start() {
		health=GameObject.Find("Health");
	}
	
	// Update is called once per frame
	void Update() {
		health.GetComponent<Health>().isReceivingDamage=!health.GetComponent<Health>().isReceivingDamage;
	}
}
