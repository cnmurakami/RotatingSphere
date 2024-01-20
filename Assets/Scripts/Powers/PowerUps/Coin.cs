using UnityEngine;
using System.Collections;

/// <summary>
/// Increases coin by amount on activation
/// </summary>
public class Coin : MonoBehaviour {
	[Tooltip("How many coins will be added")]
	public int amount;

	/// <summary>
	/// Increases coin
	/// </summary>
	void Start() {
		CoinManager.coins+=amount;
		Destroy(this.gameObject);
	}
}
