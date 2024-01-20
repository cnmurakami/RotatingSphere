using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Shows globe name based on Globe List and Globe Selection.
/// </summary>
public class ShowGlobeName : MonoBehaviour {
	[Tooltip("Text to display name")]
	public Text globeName;

	/// <summary>
	/// Gets globe prefab name minus the first 3 chars (used to categorize globes) to properly show it to the player
	/// If the globe is purchased, it will be indicated right after the name
	/// </summary>
	void Update() {
		if (GlobeSelect.tempVal!=-1) {
			string name=GlobeList.globeList[(int)GlobeSelect.tempVal].gameObject.name;
			name=name.Substring(3);
			if (GlobeList.globeList[(int)GlobeSelect.tempVal].GetComponent<Status>().purchased==true) {
				globeName.text=name+"\n(PURCHASED)";
			}
			else {
				globeName.text=name;
			}
		}
	}
}
