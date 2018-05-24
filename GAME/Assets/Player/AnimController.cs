using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour {

	Animator animator;

	float vertical;
	float horizontal;


	void Start () {
		animator = GetComponent<Animator>();
		
	}

	void Update () {
		vertical = Input.GetAxis ("Vertical");
		horizontal = Input.GetAxis ("Horizontal");

		if (vertical == 0) {
			animator.SetBool ("Walking", false);
			animator.SetBool ("WalkingBack", false);
		}

		if (vertical >= 0.1f) {
			animator.SetBool ("Walking", true);
		}

		if (vertical <= -0.1f) {
			animator.SetBool ("WalkingBack", true);
		}




		if (horizontal == 0) {
			animator.SetBool ("WalkingLeft", false);
			animator.SetBool ("WalkingRight", false);
		}

		if (horizontal >= 0.1f) {
			animator.SetBool ("WalkingRight", true);
		}

		if (horizontal <= -0.1f) {
			animator.SetBool ("WalkingLeft", true);
		}


	}
}
