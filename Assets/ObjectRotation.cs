using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour {

	//
	public GameObject globalCardboardObject;

	// a variable to hold the rotation from Cardboard
	private Quaternion localCardboardRotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// grabs cardboard rotation from the global game object
		localCardboardRotation = globalCardboardObject.GetComponent<CardboardHandler>().cardboardRotation;
		
		//convert cardboard rotation to useable euler angles
		var angles = localCardboardRotation.eulerAngles;
//		print (angles);
		float xRot = angles.x;
		float yRot = angles.y;
		float zRot = angles.z;

		//rotate the object based on the euler angles
		this.transform.Rotate (xRot, yRot, zRot);
	
	}
}
