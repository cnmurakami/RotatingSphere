using UnityEngine;
using System.Collections;
using tv.ouya.console.api;

/// <summary>
/// Randomly spawns powers
/// </summary>
public class SpawnPower : MonoBehaviour {
	[Tooltip("Generated automatically. DO NOT alter this manually")]
	public GameObject[] powerList;
	[Tooltip("Tag used on Powers")]
	public string powerTag="Power";
	[Tooltip("Minimum amount of time to spawn a new Power (in frames)")]
	public int minTime=100;
	[Tooltip("Maximum amount of time to spawn a new Power (in frames)")]
	public int maxTime=200;

	//Gets the total amount of powers from prefab folder
	protected int range;
	//Gets a Random Range between min and max Time
	protected int timer;
	//Stores elapsed time
	protected int time;
	//Gets a Random index from the list of powers
	protected int index;

	/// <summary>
	/// Creates a list with all powers from Resources/Prefabs/Powers
	/// and sets initial spawn values
	/// </summary>
	void Start() {
		#if UNITY_ANDROID && !UNITY_EDITOR

		if (OuyaSDK.OuyaInput.IsControllerConnected(0)) {
		minTime=minTime/OuyaMultiplier.value;
		maxTime=maxTime/OuyaMultiplier.value;
		}
		#endif
		powerList=Resources.LoadAll<GameObject>("Prefabs/Powers");
		range=powerList.Length;
		timer=Random.Range(minTime, maxTime);
		time=0;
	}

	/// <summary>
	/// When time reaches timer, generates a random index and spawns a power if no other power is present
	/// </summary>
	void Update() {
		if (Pause.isPaused==false) {
			time++;
			if (time>=timer) {
				index=Random.Range(0, range);
				if (!GameObject.FindGameObjectWithTag(powerTag)) {
					GameObject temp=(GameObject)Instantiate(powerList[index]);
					temp.transform.parent=this.transform;
					temp.transform.localPosition=new Vector3(0, 0, 0);
				}
				timer=Random.Range(minTime, maxTime);
				time=0;
			}
		}
	}
}