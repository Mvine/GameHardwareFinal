using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControllerState {
	Ok, Calibrating, Warning,
}

public class Controller : MonoBehaviour {
	public GameObject led;

	public ControllerState state = ControllerState.Ok;

	private void Update() {
		var mat = led.GetComponent<MeshRenderer>().material;

		switch (state) {
		case ControllerState.Ok:
			mat.color = Color.green;
			break;
		case ControllerState.Calibrating:
			mat.color = Color.blue;
			break;
		case ControllerState.Warning:
			mat.color = Color.red;
			break;
		}
	}
}
