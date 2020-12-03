using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegScript : MonoBehaviour {
	private Controller m_controller;

	private void Awake() {
		m_controller = FindObjectOfType<Controller>();
	}

	private void Update() {
		
	}
}
