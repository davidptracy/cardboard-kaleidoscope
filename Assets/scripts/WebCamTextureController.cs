using UnityEngine;
using System.Collections;

public class WebCamTextureController : MonoBehaviour {

	public WebCamTexture mCamera = null;

	// Use this for initialization
	void Start () {

		// CREATE QUADS


		// SET UP WEBCAM FEED

		mCamera = new WebCamTexture ();

		//TODO access only children of specific prefab
		foreach(Transform child in transform) {
			child.gameObject.GetComponent<Renderer>().material.mainTexture = mCamera;
		}

		mCamera.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
