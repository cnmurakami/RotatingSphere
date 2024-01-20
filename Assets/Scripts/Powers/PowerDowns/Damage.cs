using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	[Tooltip("Amount of damage received")]
	public float amount=4;

	void Start() {
		GameObject.Find("Health").GetComponent<Health>().currentHp-=GameObject.Find("Health").GetComponent<Health>().hp/amount;
	}


	void Update() {
		Destroy(this.gameObject);
	}
}
