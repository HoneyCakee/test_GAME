using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	public float speed = 1.0f;
	public float runSpeed = 15;
	public float jumpPower = 5;
	Rigidbody rigidBody;
	float horizontal;
	float vertical;

	void Start(){
	
		rigidBody = GetComponent<Rigidbody> ();
	
	}

	void Update () {
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");
		rigidBody.AddForce (((transform.right * horizontal) + (transform.forward * vertical) * speed / Time.deltaTime));
	}
}