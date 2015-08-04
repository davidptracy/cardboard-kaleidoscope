using UnityEngine;
using System.Collections;

public class WebCamMaterial : MonoBehaviour {

	private GameObject eventSystem;
	private WebCamTexture camMat;

	// Use this for initialization
	void Start () {

		//pull the webcam material from the event system
		eventSystem = GameObject.Find ("EventSystem");
		camMat = eventSystem.GetComponent<WebCamSrc> ().camTexture;

		print (camMat.GetType ());

		// apply the webcam material to the object
		this.GetComponent<Renderer> ().material.mainTexture = camMat;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
