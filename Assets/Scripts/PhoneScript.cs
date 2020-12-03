using System.Collections;
using System.Collections.Generic;
using Unity.Rendering.HybridV2;
using UnityEngine;

public class PhoneScript : MonoBehaviour {
	private Controller m_controller;

	private void Awake() {
		m_controller = FindObjectOfType<Controller>();
	}

	private void Update() {
		var dot = Vector3.Dot(transform.up, Vector3.up);

		if (dot < Mathf.Cos(10f * Mathf.Deg2Rad)) {
			m_controller.state = ControllerState.Warning;
		} else {
			m_controller.state = ControllerState.Ok;
		}
	}
}
