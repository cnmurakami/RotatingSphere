using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {
	/// <summary>
	/// Makes the object which it is attached to align itself with the camera.
	/// </summary
	/// <remarks>
	/// Original script from http://wiki.unity3d.com/index.php?title=CameraFacingBillboard.
	/// </remarks>


	/// <summary>he camera.</summary>

	/// <summary>The camera transform./summary>
	protected Transform cameraTransform;

	protected void Awake() {

		if (this.GetComponent<Camera>()==null) {
			this.cameraTransform=Camera.main.GetComponent<Transform>();
		}
		else {
			this.cameraTransform=this.GetComponent<Camera>().GetComponent<Transform>();
		}
	}

	protected void Update() {
		this.transform.LookAt(transform.position+this.cameraTransform.rotation*Vector3.forward,
			this.cameraTransform.rotation*Vector3.up);
	}
	
}
