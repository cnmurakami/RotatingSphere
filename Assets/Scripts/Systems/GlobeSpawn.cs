using UnityEngine;
using System.Collections;

/// <summary>
/// Spawns the selected Globe and Orb
/// </summary>
public class GlobeSpawn : MonoBehaviour {
	[Tooltip("Orb GameObject")]
	public GameObject orb;

	/// <summary>
	/// Gets the selected globe value from GlobeSelect and instantiate it from the GlobeList index
	/// </summary>
	void Start() {
		GameObject Globe=Instantiate(GlobeList.globeList[GlobeSelect.globe]) as GameObject;
		GameObject Orb=Instantiate(orb) as GameObject;
	}
}
