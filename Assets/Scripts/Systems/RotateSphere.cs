using UnityEngine;
using System.Collections;

/// <summary>
/// Currently not used.
/// </summary>
public class RotateSphere : MonoBehaviour {
	int speed=12;
	float friction=0.5f;
	float lerpSpeed=1.5f;
	float xDeg;
	float yDeg;
	Quaternion fromRotation;
	Quaternion toRotation;

	void Start() {

	}

	void Update() {
		if (Input.GetMouseButton(0)) {
			xDeg-=Input.GetAxis("Mouse X")*speed*friction;
			yDeg+=Input.GetAxis("Mouse Y")*speed*friction;
		}
		fromRotation=transform.rotation;
		toRotation=Quaternion.Euler(yDeg, xDeg, 0);
		transform.rotation=Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime*lerpSpeed);
		//Debug.Log("== "+toRotation);
	}
}
