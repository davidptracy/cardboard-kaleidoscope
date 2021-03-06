﻿// C# script for a 3D kaleidoscope.
// This class generates a ring of cubes that rotate and orient themselves toward the camera.
// This script should be attached to an event system alongside CardboardHandler.cs
// 2015 by David Tracy @ Rockwell Group Lab

using UnityEngine;
using System.Collections;
using System.Collections.Generic; // for lists

public class RadialCubes : MonoBehaviour {

	public GameObject cardboardHead; //a reference to the cardboard 'head'
	public GameObject globalCardboardObject; //a reference to the cardboardHandler script to get rotation values
	private GameObject target; //a dummy target to visualize the target of the camera
	private GameObject circle; //a parent gameObject to nest the cubes under, used for transformations

	private WebCamTexture mCamera = null; //an empty webcam texture

	private Vector3 basePoint; //basepoint for the circle origin
	private Vector3 camHeading; //vector for rotation relative to camera
	private Vector3 camUp; //vector for rotation relative to camera
	private int cubeCount; //the amount of cubes for the radial array
	private float radius; //the radius at which to place the cubes
	private float rotation; //the global rotation of the circle
	private float offset; //distance at which to orient the center of the circle
	private List<GameObject> cubes; //array to hold the cubes generated by the mesh

	private Quaternion localCardboardRotation; //variable to hold the current rotation from Cardboard
	private Quaternion lastLocalCardboardRotation; //variable to hold the last rotation from Cardboard
	
	// Use this for initialization
	void Start () {

		//a list to hold all the cubes
		cubes = new List<GameObject> ();

		//the forward direction and up directions of the camera
		camHeading = cardboardHead.transform.forward;
//		camUp = cardboardHead.transform.up;

		offset = 2.0f;
		cubeCount = 10;
		radius = 1.0f;
		rotation = 0.25f;
		basePoint = camHeading*radius;
//		basePoint = new Vector3 (Random.Range (2.0f, 5.0f), Random.Range (2.0f, 5.0f), Random.Range (2.0f, 5.0f));

		circle = new GameObject();
		circle.transform.position = basePoint;

		// instantiate the webcam
		mCamera = new WebCamTexture ();
					
		//create the cubes
		for (int i=0; i < cubeCount; i++) {
			//generate a cube
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			//move the cube to the basepoint
			cube.transform.position = basePoint;
			//scale the cubes
//			cube.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
			//orient the cube toward the camera
			cube.transform.LookAt(this.transform.position);
			//move that cube to the side
			cube.transform.position = basePoint + cube.transform.right*radius;
			//rotate the cubes around the basePoint
			cube.transform.RotateAround(basePoint, basePoint - this.transform.position, i*360/cubeCount);
			//incremental rotation
			cube.transform.Rotate(cube.transform.forward, i*(360/cubeCount));
			//parent the cube to the empty circle object
			cube.transform.parent = circle.transform;
			//set the webcamTexture as the mainTexture for the cube
			cube.GetComponent<Renderer>().material.mainTexture = mCamera;
			//add the cube to the list
			cubes.Add(cube);
		}

		//use a sphere as the target
		target = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		//shrink the sphere
		target.transform.localScale -= new Vector3 (0.75f, 0.75f, 0.75f);
		//push the sphere away from the camera using its forward direction
		target.transform.position = offset * camHeading;

		//play the webcam material
		mCamera.Play ();

	}
	
	// Update is called once per frame
	void Update () {

		//update the camera heading
		camHeading = cardboardHead.transform.forward;
		basePoint = offset * camHeading;

		//convert cardboard's quaternion to useable euler angles
		localCardboardRotation = this.GetComponent<CardboardHandler>().cardboardRotation;
		Vector3 angles = localCardboardRotation.eulerAngles;
		Vector3 lastAngles = lastLocalCardboardRotation.eulerAngles;

		for ( int i = 0; i < cubes.Count; i++ ) {
			//slowly rotate the cubes around their circle's basepoint
			cubes[i].transform.RotateAround(basePoint, this.transform.position - basePoint, rotation);
			cubes[i].transform.Rotate (angles-lastAngles);

		}

		//move the cubes in and out **VOMIT**
//		circle.transform.position = camHeading * Mathf.Abs (Mathf.Sin (sinWave));
		//move the circle of cubes to the center of the camera's target
		circle.transform.position = radius * camHeading;
		//make the circle of cubes look at the origin
		circle.transform.LookAt (this.transform.position);

		//set the last cardboard rotate to the current rotation so we can measure the difference in the next loop
        lastLocalCardboardRotation = localCardboardRotation;
			
	}
}