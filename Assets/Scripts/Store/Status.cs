using UnityEngine;
using System.Collections;

/// <summary>
/// Store purchase status and value of the globe.
/// </summary>
public class Status : MonoBehaviour {
	[Tooltip("Is this Globe purchased?")]
	public bool purchased;
	[Tooltip("Cost amount to be purchased")]
	public int cost;
}
