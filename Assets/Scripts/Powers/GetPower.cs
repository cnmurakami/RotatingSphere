using UnityEngine;
using System.Collections;

/// <summary>
/// Makes the player be able to get powers
/// </summary>
public class GetPower : MonoBehaviour {
	[Tooltip("Tag of the Focus collider")]
	public string FocusTag="Focus";
	[Tooltip("Power to be aquired after it is got (aa_power from PowerActivators)")]
	public GameObject power;

	/// <summary>
	/// Instantiates the power to be aquired and destroys itself
	/// </summary>
	void OnTriggerEnter(Collider col) {
		if (col.CompareTag(FocusTag)) {
			GameObject temp=Instantiate(power);
			Destroy(this.gameObject);
		}
	}
}
