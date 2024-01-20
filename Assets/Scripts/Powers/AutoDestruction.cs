using UnityEngine;
using System.Collections;

/// <summary>
/// Auto destroys the power if the player fails to get it after a certain time
/// </summary>
public class AutoDestruction : MonoBehaviour {
	[Tooltip("Duration of the Power before it is destroyed")]
	public int duration=300;
	protected int time=0;

	void Start() {
		#if UNITY_ANDROID && !UNITY_EDITOR

		if (OuyaSDK.OuyaInput.IsControllerConnected(0)) {
			time=time/OuyaMultiplier.value;
		}

		#endif
	}

	/// <summary>
	/// If the designated time is passed, the power is destroyed
	/// </summary>
	void Update() {
		if (Pause.isPaused==false) {
			time++;
			if (time>=duration) {
				Destroy(this.gameObject);
			}
		}
	}
}
