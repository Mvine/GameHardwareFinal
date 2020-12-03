using System.Collections;
using System.Collections.Generic;
using Unity.Rendering.HybridV2;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PhoneScript : MonoBehaviour {
	private Controller m_controller;

	private Vector3 m_currentUp;

	private bool m_calibrationHeld;

	[SerializeField]
	private float innaccuracy;

	private void Awake() {
		m_controller = FindObjectOfType<Controller>();
	}

	private void Start() {
		m_currentUp = Vector3.up;
	}

	private void Update() {
		var dot = Vector3.Dot(transform.up, Quaternion.Euler(innaccuracy, 0, 0) * m_currentUp);

		if (m_controller.state != ControllerState.Calibrating) {
			m_controller.state =
				dot < Mathf.Cos(30f * Mathf.Deg2Rad)
					? ControllerState.Warning
					: ControllerState.Ok;
		}
	}

	public void Calibrate() {
		m_currentUp = transform.up;

		m_controller.state = ControllerState.Calibrating;
	}

	private void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, 300, 100));
		{
			GUILayout.BeginHorizontal();
			{
				GUILayout.TextArea("Innaccuracy");

				innaccuracy = GUILayout.HorizontalSlider(innaccuracy, -30, 30);

			}
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			{
				bool repeat = GUILayout.RepeatButton("Calibrate");

				m_calibrationHeld = GUILayout.Toggle(m_calibrationHeld, "Toggle");

				if (repeat) {
					m_calibrationHeld = false;
				}

				if (repeat || m_calibrationHeld) {
					Calibrate();
				} else {
					m_controller.state = ControllerState.Ok;
				}

			}
			GUILayout.EndHorizontal();
		}
		GUILayout.EndArea();
	}
}
