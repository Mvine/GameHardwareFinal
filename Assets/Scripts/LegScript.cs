using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegScript : MonoBehaviour {
	private Controller m_controller;

	private Vector3 m_startPosition;

	public bool shake;

	private void Awake() {
		m_controller = FindObjectOfType<Controller>();
	}

	private void Start() {
		m_startPosition = transform.localPosition;
	}

	private void Update() {
		if (shake) {
			transform.localPosition = m_startPosition + Random.insideUnitSphere * 0.01f;
		} else {
			transform.localPosition = m_startPosition;
		}
	}
}
