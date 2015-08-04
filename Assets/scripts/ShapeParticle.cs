using UnityEngine;
using System.Collections;

public class ShapeParticle : MonoBehaviour {

	private int lifeSpan;
	private Vector3 location, velocity;

	// Use this for initialization
	void Start () {
		location = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);

		// find the vector between the origin and the camera's position. clue: origin
//		velocity = new Vector3(location - new Vector3(0.0f, 0.0f, 0.0f));
		// normalize that vector
//		velocity = Vector3.Normalize (velocity);

//		GameObject shape = GameObject.CreatePrimitive(PrimitiveType.Cube);
//		shape.transform.position = new Vector3(location);
		// get the webcam texture
//		shape.GetComponent<Renderer>().material.mainTexture = mCamera;
	}

	// Update is called once per frame
	void Update () {
		lifeSpan ++;
		location += velocity;
	}

	private bool isDead(){
		if (lifeSpan > 1000) {
			return true;
		} else {
			return false;
		}
	}

}
