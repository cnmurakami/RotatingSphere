using UnityEngine;
using System.Collections;

/// <summary>
/// Enables and disables orb focus effect
/// </summary>
public class OrbFocusParticles : MonoBehaviour {
	[Tooltip("Particle System for the Focus Effect")]
	public ParticleSystem focusEffect;

	// Use this for initialization
	void Start() {
		focusEffect.Stop();
	}
	
	// Update is called once per frame
	void Update() {
		if (this.GetComponent<FocusCoin>().isActive==true && focusEffect.isStopped) {
			focusEffect.Play();
		}
		else {
			focusEffect.Stop();
		}
	}
}
