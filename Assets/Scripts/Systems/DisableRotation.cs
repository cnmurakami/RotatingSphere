using UnityEngine;
using System.Collections;

/// <summary>
/// Not currently in use
/// </summary>
public class DisableRotation : MonoBehaviour {
	protected float speed;
	// Use this for initialization
	void Start() {
		speed=this.gameObject.GetComponentInParent<MoveOrb>().speed;
	}
	
	// Update is called once per frame
	void Update() {
		if (GameObject.FindGameObjectWithTag("Power")) {
			this.gameObject.GetComponentInParent<MoveOrb>().speed=0;
		}
		else {
			this.gameObject.GetComponentInParent<MoveOrb>().speed=speed;
		}
	}
}
