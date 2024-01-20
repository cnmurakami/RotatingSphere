using UnityEngine;
using System.Collections;

/// <summary>
/// Adds coins to tempCoins by focusing the orb
/// </summary>
public class FocusCoin : MonoBehaviour {
	public bool isActive;
	[Tooltip("Tag of the Focus collider")]
	public string focusTag;
	//Focus points are given while focusing the orb;
	protected float focusPoints;
	[Tooltip("Required focus points to earn a coin")]
	public int reqFocus;

	// Use this for initialization
	void Start() {
		isActive=false;
	}

	/// <summary>
	/// While active (player is focusing the orb), Focus Points are given
	/// When Focus Points meets the Required Focus, a coin is given to the temporary coin
	/// </summary>
	void FixedUpdate() {
		if (isActive) {
			focusPoints+=1*Time.timeScale;
		}
		if (focusPoints>=reqFocus) {
			focusPoints-=reqFocus;
			print("+1 COIN");
			CoinManager.tempCoin+=1;
		}
	}

	/// <summary>
	/// Activates when orb is focused
	/// </summary>
	/// <param name="col">The collider from Coin Focus</param>
	void OnTriggerEnter(Collider col) {
		if (col.CompareTag(focusTag)) {
			isActive=true;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.CompareTag(focusTag)) {
			isActive=false;
		}
	}
}
