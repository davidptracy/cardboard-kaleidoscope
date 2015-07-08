using UnityEngine;
using System.Collections;

public class WebCamSrc : MonoBehaviour {

	public WebCamTexture camTexture = null;

	// Use awake instead of Start() to ensure that the webCam texture is initialized
	// before the geometry is loaded elsewhere
	void Awake () {
		
		camTexture = new WebCamTexture ();
		camTexture.Play ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
