using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControllerState {
	Ok, Calibrating, Warning,
}

public class Controller : MonoBehaviour {
	private LegScript m_leg;

	[SerializeField]
	private GameObject led;

	public ControllerState state = ControllerState.Ok;

	private void Awake() {
		m_leg = FindObjectOfType<LegScript>();
	}

	private void Update() {
		var mat = led.GetComponent<MeshRenderer>().material;

		switch (state) {
		case ControllerState.Ok:
			mat.color   = Color.green;
			m_leg.shake = false;
			break;
		case ControllerState.Calibrating:
			mat.color   = new Color(0.2f, 0.5f, 1f);
			m_leg.shake = false;
			break;
		case ControllerState.Warning:
			mat.color   = Color.red;
			m_leg.shake = true;
			break;
		}
	}
}
