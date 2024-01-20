using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Displays health on UI
/// </summary>
public class HealthDisplay : MonoBehaviour {
	[Tooltip("Slider to display health")]
	public Slider healthSlider;
	[Tooltip("Health bar fill")]
	public Image healthFill;
	//Gets the maxHp to save cpu time
	protected float maxHp;

	void Start() {
		maxHp=this.GetComponent<Health>().hp;
	}

	
	/// <summary>
	/// Gets health values from Health script and converts them to health bar
	/// </summary>
	void Update() {
		//Changes health bar size based on health percentage
		healthSlider.value=this.GetComponent<Health>().currentHp/maxHp;

		//Changes health bar color based on percentage
		if ((this.GetComponent<Health>().currentHp*1/maxHp)>=0.5f) {
			healthFill.color=new Color((1f-((this.GetComponent<Health>().currentHp/2)/maxHp)), 1, 0, 1);
		}
		else if ((this.GetComponent<Health>().currentHp*1/maxHp)<0.5f) {
			healthFill.color=new Color(1, (this.GetComponent<Health>().currentHp)/(maxHp/2), 0, 1);
		}
	}
}
