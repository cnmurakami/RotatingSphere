using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using tv.ouya.console.api;

/// <summary>
/// Creates a preview of the selected globe
/// </summary>
public class PreviewGlobe : MonoBehaviour {
	[Tooltip("Slider to browse globes")]
	public Slider slider;
	[Tooltip("Location to preview")]
	public GameObject preview;
	[Tooltip("Scale of preview")]
	public float scale;
	[Tooltip("Speed rotation of preview")]
	public float rotSpeed;
	protected GameObject viewGlobe;
	protected float tempVal;
	protected bool isMoving=false;

	void Start() {
		ShowPreview();
	}

	/// <summary>
	/// Whenever the slider value changes, it will change the globe being viewed
	/// </summary>
	void Update() {
		viewGlobe.transform.Rotate(0, rotSpeed, 0);
		if (slider.value!=tempVal) {
			GameObject.Destroy(viewGlobe);
			ShowPreview();
		}
		tempVal=slider.value;
		#if UNITY_ANDROID && !UNITY_EDITOR

		if (OuyaSDK.OuyaInput.IsControllerConnected(0)) {
			var axisHorizontal = OuyaSDK.OuyaInput.GetAxis(0, 
              	OuyaController.AXIS_LS_X);
			var axisVertical = OuyaSDK.OuyaInput.GetAxis(0, 
          		OuyaController.AXIS_LS_Y);

		if (axisVertical>-0.2f && axisVertical<0.2f){
			isMoving=false;
		}
			if (axisVertical == 1f && isMoving==false){
          		slider.value+=1;
          		isMoving=true;
          	}
			if (axisVertical == -1f && isMoving==false){
          		slider.value-=1;
          		isMoving=true;
          	}

		}

		#endif
	}

	/// <summary>
	/// Creates a instance of the selected globe, adjusts position and size and makes it child of the preview place holder
	/// </summary>
	void ShowPreview() {
		viewGlobe=Instantiate(GlobeList.globeList[(int)slider.value]);
		viewGlobe.transform.position=preview.transform.position;
		viewGlobe.transform.localScale=new Vector3(scale, scale, scale);
		viewGlobe.transform.parent=preview.transform;
		viewGlobe.GetComponent<RotateSphere2>().enabled=false;
	}
}
