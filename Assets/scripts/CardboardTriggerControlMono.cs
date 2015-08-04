using UnityEngine;
using System.Collections;

public class CardboardTriggerControlMono : MonoBehaviour {

	public GameObject eventSystem; 
	public bool magnetDetectionEnabled = true;
	private bool videoTrigger;
	
	void Start() {
		cardboardMagnetSensor.SetEnabled(magnetDetectionEnabled);
		videoTrigger = eventSystem.GetComponent<RadialSphere>().videoEnabled;
		// Disable screen dimming:
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	} 
	
	void Update () {
		if (!magnetDetectionEnabled) return;
		if (cardboardMagnetSensor.CheckIfWasClicked()) {
			videoTrigger = !videoTrigger;
			Debug.Log("DO SOMETHING HERE");  // PERFORM ACTION.
			cardboardMagnetSensor.ResetClick();
		}
	}
}