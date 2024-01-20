using UnityEngine;
using System.Collections;

/// <summary>
/// Generates a list of all globe prefabs to be accessed by other scripts
/// </summary>
public class GlobeList : MonoBehaviour {
	[Tooltip("Generated automatically. DO NOT alter this manually")]
	public static GameObject[] globeList;

	/// <summary>
	/// Loads all the prefabs at Resources/Prefabs/Globes
	/// </summary>
	void Awake() {
		globeList=Resources.LoadAll<GameObject>("Prefabs/Globes");
	}
}
