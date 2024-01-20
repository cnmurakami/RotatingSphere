using UnityEngine;
using System.Collections;

/// <summary>
/// Heals health by amount on activation.
/// </summary>
public class Heal : MonoBehaviour {
	[Tooltip("Amount of health received")]
	public float amount=4;
	// Use this for initialization
	void Start() {
		GameObject.Find("Health").GetComponent<Health>().currentHp+=GameObject.Find("Health").GetComponent<Health>().hp/amount;
	}

	/// <summary>
	/// Checks if resulting health is higher than maximum health and if true, equals it
	/// </summary>
	void Update() {
		if (GameObject.Find("Health").GetComponent<Health>().currentHp>GameObject.Find("Health").GetComponent<Health>().hp) {
			GameObject.Find("Health").GetComponent<Health>().currentHp=GameObject.Find("Health").GetComponent<Health>().hp;
		}
		Destroy(this.gameObject);
	}
}
