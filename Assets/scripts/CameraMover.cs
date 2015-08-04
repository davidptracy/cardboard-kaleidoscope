using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {
	float amplitudeX = 5.0f;
	float amplitudeY = 5.0f;
	float omegaX = 1.0f;
	float omegaY = 1.0f;
	float index;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		index += Time.deltaTime;
		float x = amplitudeX*Mathf.Cos (omegaX*index);
		float y = Mathf.Abs (amplitudeY*Mathf.Cos (omegaY*index));
		transform.localPosition= new Vector3(x,y,-10);
	}
}
