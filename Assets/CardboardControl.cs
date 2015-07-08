using UnityEngine;
using System.Collections;

public class CardboardControl : MonoBehaviour {

	// Which types of tracking this instance will use.
	public bool trackRotation = true;
	public bool trackPosition = true;

	// Determine whether head updates early or late in frame.
	// Defaults to false in order to reduce latency.
	// Set this to true if you see jitter due to other scripts using this
	// object's orientation (or a child's) in their own LateUpdate() functions,
	// e.g. to cast rays.
	public bool updateEarly = false;

	// If set, the head transform will be relative to it.
	public Transform target;
	
	// Where is this head looking?
	public Ray Gaze {
		get {
			UpdateHead();
			return new Ray(transform.position, transform.forward);
		}
	}

	private bool updated;
	
	void Update() {
		updated = false;  // OK to recompute head pose.
		if (updateEarly) {
			UpdateHead ();
		}
	}

	// Normally, update head pose now.
	void LateUpdate() {
		UpdateHead();
	}
	
	// Compute new head pose.
	private void UpdateHead() {
		if (updated) {  // Only one update per frame, please.
			return;
		}
		updated = true;
		Cardboard.SDK.UpdateState();
		
		if (trackRotation) {
			var rot = Cardboard.SDK.HeadPose.Orientation;
			if (target == null) {
				transform.localRotation = rot;
			} else {
				transform.rotation = rot * target.rotation;
			}
		}
		
		if (trackPosition) {
			Vector3 pos = Cardboard.SDK.HeadPose.Position;
			if (target == null) {
				transform.localPosition = pos;
			} else {
				transform.position = target.position + target.rotation * pos;
			}
		}
	}
		
		
	}
	