using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Hides when behind globe and also disables its light and particles (if any).
/// </summary>
public class HideWhenBehindGlobe : MonoBehaviour {
	[Tooltip("Attached Power Canvas")]
	public Canvas powerCanvas;

	void Update() {
		if (this.transform.position.z>0) {
			powerCanvas.enabled=false;
			if (this.gameObject.GetComponentInChildren<Light>()) {
				this.gameObject.GetComponentInChildren<Light>().enabled=false;
			}
			if (this.gameObject.GetComponentInChildren<ParticleSystem>()) {
				this.gameObject.GetComponentInChildren<ParticleSystem>().enableEmission=false;
			}
		}
		else {
			powerCanvas.enabled=true;
			if (this.gameObject.GetComponentInChildren<Light>()) {
				this.gameObject.GetComponentInChildren<Light>().enabled=true;
			}
			if (this.gameObject.GetComponentInChildren<ParticleSystem>()) {
				this.gameObject.GetComponentInChildren<ParticleSystem>().enableEmission=true;
			}
		}
	}
}
