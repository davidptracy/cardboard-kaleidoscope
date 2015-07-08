using UnityEngine;
using System.Collections;

public class autoRotate : MonoBehaviour {

	private float xRot, yRot, zRot;

	// Use this for initialization
	void Start () {

		xRot = 0.0f;
		yRot = 0.0f;
		zRot = 45.0f;

		this.transform.Rotate(xRot,yRot,zRot);
	
	}
	
	// Update is called once per frame
	void Update () {

		zRot += .001f;
		this.transform.Rotate(xRot,yRot,zRot);
	
	}
}
