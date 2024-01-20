using UnityEngine;
using System.Collections;
using tv.ouya.console.api;

/// <summary>
/// Manages owned coins
/// </summary>
public class CoinManager : MonoBehaviour {
	// Coins owned;
	public static int coins;
	// Coins got during a game by focusing the orb
	// Note that tempCoins are only obtained after losing the game
	public static int tempCoin;

	void Start() {
		if (GameObject.Find("EndGame")) {
			coins+=tempCoin;
		}
		if (GameObject.Find("CoinManager").GetComponent<ConvertScoreToCoin>()==true) {
			GameObject.Find("CoinManager").GetComponent<ConvertScoreToCoin>().focusCoin=tempCoin;
		}
		tempCoin=0;
	}

	/// <summary>
	/// Cheat for presentation purposes only
	/// </summary>
	void Update() {
		if (Input.GetButtonDown("GiveMeCoins")) {
			coins+=5;
		}
		#if UNITY_ANDROID && !UNITY_EDITOR

		if (OuyaSDK.OuyaInput.IsControllerConnected(0)) {
			var button_L1 = OuyaSDK.OuyaInput.GetButtonDown(0, OuyaController.BUTTON_L1);
			if (button_L1){
				coins+=5;
			}
		}

		#endif
	}
}
