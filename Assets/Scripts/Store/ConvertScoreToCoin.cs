using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Convert score to coin and show results.
/// </summary>
public class ConvertScoreToCoin : MonoBehaviour {
	[Tooltip("Text to display results")]
	public Text coinBoard;
	[Tooltip("Score required to gain each coin")]
	public int reqScore;
	public int focusCoin;

	/// <summary>
	/// Show results
	/// </summary>
	void Start() {
		CoinManager.coins+=(int)Score.score/reqScore;
		coinBoard.text="Coins Earned: "+((int)Score.score/reqScore+focusCoin)+" - Total Coins: "+CoinManager.coins;
	}
}
