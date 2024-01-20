using UnityEngine;
using System.Collections;

/// <summary>
/// Checks wheter the Orb is behind the Globe or not and changes damage status
/// Also hides the Orb when it is behind the Globe in case the Globe is transparent, but leaves its light on
/// </summary>
public class OrbCheckDamage : MonoBehaviour {
	public Light light1;
	public Light light2;

	void Update() {
		if (this.transform.position.z>0) {
			//Sets the Health status to receive damage
			GameObject.Find("Health").GetComponent<Health>().isReceivingDamage=true;
			//Hides the Orb
			this.GetComponent<MeshRenderer>().enabled=false;
			light1.enabled=false;
			light2.enabled=false;
		}
		else {
			GameObject.Find("Health").GetComponent<Health>().isReceivingDamage=false;
			this.GetComponent<MeshRenderer>().enabled=true;
			light1.enabled=true;
			light2.enabled=true;
		}
	}
}