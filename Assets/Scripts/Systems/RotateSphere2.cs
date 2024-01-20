using UnityEngine;
using System.Collections;
using tv.ouya.console.api;

/// <summary>
/// Rotates the attached object by mouse X and Y axis movement based on sensitivity settings;
/// </summary>
public class RotateSphere2 : MonoBehaviour {
	[Tooltip("Sensitive level on X axis")]
	public float sensitivityX=5.0f;
	[Tooltip("Sensitive level on Y axis")]
	public float sensitivityY=5.0f;
	private Transform cameraTm;
	protected float rotationX;
	protected float rotationY;
	protected float speedX;
	protected float speedY;

	/// <summary>
	/// Sets the camera used to track object
	/// </summary>
	void Start() {
		speedX=sensitivityX;
		speedY=sensitivityY;
		cameraTm=Camera.main.transform;
	}

	/// <summary>
	/// Gets mouse axis inputs and rotates based on sensitivity;
	/// </summary>
	void Update() {
		if (Pause.isPaused==false) {
			#if UNITY_ANDROID && !UNITY_EDITOR
				if (OuyaSDK.OuyaInput.IsControllerConnected(0)) {
					var axisHorizontal=OuyaSDK.OuyaInput.GetAxis(0, OuyaController.AXIS_LS_X);
					var axisVertical=OuyaSDK.OuyaInput.GetAxis(0, OuyaController.AXIS_LS_Y);
					var button_R2 = OuyaSDK.OuyaInput.GetAxis(0, OuyaController.AXIS_R2);


					if (button_R2>0){
						speedX=sensitivityX*(1+button_R2);
						speedY=sensitivityY*(1+button_R2);
					}
					else{
						speedX=sensitivityX;
						speedY=sensitivityY;
					}
					rotationX=-axisHorizontal*speedX;
					rotationY=axisVertical*speedY;
					transform.RotateAroundLocal(cameraTm.up, -Mathf.Deg2Rad*rotationX);
					transform.RotateAroundLocal(cameraTm.right, Mathf.Deg2Rad*rotationY);
				}
			#endif
		
			
			rotationX=Input.GetAxis("Mouse X")*sensitivityX;
			rotationY=Input.GetAxis("Mouse Y")*sensitivityY;
			transform.RotateAroundLocal(cameraTm.up, -Mathf.Deg2Rad*rotationX);
			transform.RotateAroundLocal(cameraTm.right, Mathf.Deg2Rad*rotationY);
			
		}
	}
}
