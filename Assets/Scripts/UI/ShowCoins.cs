using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Display owned coins
/// </summary>
public class ShowCoins : MonoBehaviour {
	[Tooltip("Text do display owned coins")]
	public Text display;

	// Use this for initialization
	void Start() {
		display.text="Coins owned: "+CoinManager.coins;
	}
	
	// Update is called once per frame
	void Update() {
		display.text="Coins owned: "+CoinManager.coins;
	}
}
