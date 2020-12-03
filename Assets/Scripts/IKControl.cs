using UnityEngine;

// Taken from https://docs.unity3d.com/Manual/InverseKinematics.html

[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour {
	protected Animator m_animator;

	public bool      ikActive  = false;
	public Transform leftFoot  = null;
	public Transform rightFoot = null;

	void Start() {
		m_animator = GetComponent<Animator>();

		transform.localPosition = new Vector3(0, 1, 0);
	}

	//a callback for calculating IK
	void OnAnimatorIK(int a_layerIndex) {
		if (m_animator) {

			//if the IK is active, set the position and rotation directly to the goal. 
			if (ikActive) {

				// Set the right hand target position and rotation, if one has been assigned
				if (leftFoot != null) {
					m_animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
					m_animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
					m_animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFoot.position);
					m_animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFoot.rotation);
				}

				if (rightFoot != null) {
					m_animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
					m_animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
					m_animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFoot.position);
					m_animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFoot.rotation);
				}
			}

			//if the IK is not active, set the position and rotation of the hand and head back to the original position
			else {
				m_animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
				m_animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);
				m_animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
				m_animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);
			}
		}
	}
}
