using UnityEngine;
using System.Collections;

public class MeshReverse : MonoBehaviour {

	// Use this for initialization
	void Start () {

		var mesh = this.GetComponent<Mesh> ();


		//C# or UnityScript
		var indices = mesh.triangles;
		var triangleCount = indices.Length / 3;
		for(var i = 0; i < triangleCount; i++)
		{
			var tmp = indices[i*3];
			indices[i*3] = indices[i*3 + 1];
			indices[i*3 + 1] = tmp;
		}
		mesh.triangles = indices;
		// additionally flip the vertex normals to get the correct lighting
		var normals = mesh.normals;
		for(var n = 0; n < normals.Length; n++)
		{
			normals[n] = -normals[n];
		}
		mesh.normals = normals;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
