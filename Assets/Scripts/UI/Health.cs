using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages health
/// </summary>
public class Health : MonoBehaviour {
	[Tooltip("Max Health")]
	public float hp=100;
	[Tooltip("Curent Health. DO NOT CHANGE")]
	public float currentHp;
	[Tooltip("Damage to be received when Orb is behind Globe")]
	public float damage=0.2f;
	[Tooltip("Amount to be restored (will be damage/restore")]
	public float restore=3;
	[Tooltip("Checks if it should receive damage. DO NOT CHANGE")]
	public bool isReceivingDamage=false;


	/// <summary>
	/// Sets the Current Health to Max Health at the start of a game
	/// </summary>
	void Start() {
		#if UNITY_ANDROID && !UNITY_EDITOR

		if (OuyaSDK.OuyaInput.IsControllerConnected(0)) {
			damage=damage*OuyaMultiplier.value;
		}

		#endif
		currentHp=hp;
	}

	/// <summary>
	/// Checks if it is receiving damage
	/// If not, restores health
	/// </summary>
	void Update() {
		if (Pause.isPaused==false) {
			if (isReceivingDamage==true) {
				currentHp-=damage;
			}
			else {
				if (currentHp<hp) {
					currentHp+=damage/restore;
				}
				else {
					currentHp=hp;
				}
			}
			// If health reaches 0, terminates the game
			if (currentHp<=0) {
				SceneManager.LoadScene("Endgame");
			}
		}
	}
}
