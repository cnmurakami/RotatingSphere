using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Select a globe based on the GlobeList using a slider
/// </summary>
public class GlobeSelect : MonoBehaviour {
	//Selected globe
	public static int globe=-1;
	[Tooltip("Slider to browse globe")]
	public Slider slider;
	[Tooltip("Button to select globe")]
	public Button select;
	public static float tempVal=-1;

	/// <summary>
	/// Adjust the slider to fit the amount of globes and checks if it is the first time the player is entering the screen
	/// If it is not, then the value of the slider will be the same as last selected
	/// </summary>
	void Start() {
		slider.maxValue=GlobeList.globeList.Length-1;
		if (globe==-1) {
			globe=0;
		}
		slider.value=globe;
		tempVal=slider.value;
	}

	/// <summary>
	/// Changes the selected globe value to the one selected on the slider
	/// </summary>
	void Update() {
		if (GlobeList.globeList[(int)slider.value].GetComponent<Status>().purchased==true) {
			if ((int)slider.value==globe) {
				select.GetComponentInChildren<Text>().text="SELECTED";
				select.interactable=false;
			}
			else {
				select.GetComponentInChildren<Text>().text="SELECT";
				select.interactable=true;
			}
		}
		else {
			if (CoinManager.coins>=GlobeList.globeList[(int)slider.value].GetComponent<Status>().cost) {
				select.GetComponentInChildren<Text>().text="PURCHASE ("+GlobeList.globeList[(int)GlobeSelect.tempVal].GetComponent<Status>().cost+" coins)";
				select.interactable=true;
			}
			else {
				select.GetComponentInChildren<Text>().text="Not enough coins ("+GlobeList.globeList[(int)GlobeSelect.tempVal].GetComponent<Status>().cost+")";
				select.interactable=false;
			}

		}
		tempVal=slider.value;
	}

	public void Select() {
		if (GlobeList.globeList[(int)slider.value].GetComponent<Status>().purchased==true) {
			globe=(int)slider.value;
		}
		if (GlobeList.globeList[(int)slider.value].GetComponent<Status>().purchased==false) {
			if (CoinManager.coins>=GlobeList.globeList[(int)slider.value].GetComponent<Status>().cost) {
				GlobeList.globeList[(int)slider.value].GetComponent<Status>().purchased=true;
				CoinManager.coins-=GlobeList.globeList[(int)slider.value].GetComponent<Status>().cost;
				globe=(int)slider.value;
			}
		}
	}
}
