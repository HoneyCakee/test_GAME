using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	public float walkSpeed = 10;
	public float runSpeed = 15;
	public float jumpPower = 5;
	public LayerMask cast;
	bool isGrounded;
	bool isUpEmpty;
	float startColHeight;
	CapsuleCollider caps;

	void Start(){
		caps = GetComponent<CapsuleCollider>();
		startColHeight = caps.height;
	}

	void Update () {
		isGrounded = Physics.Raycast(transform.position+caps.center,Vector3.down,caps.height/2+0.1f,cast);
		isUpEmpty = !Physics.Raycast(transform.position+caps.center,Vector3.up,caps.height+0.1f,cast);
		Vector3 forse = transform.TransformDirection(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		bool crouch = Input.GetKey(KeyCode.C);
		if(crouch){
			caps.height = startColHeight/2;
			caps.center = new Vector3(0,0.5f,0);
			walkSpeed = 5;
			runSpeed = 5;
			jumpPower = 0;

		}
		else if(isUpEmpty){
			caps.height = startColHeight;
			caps.center = new Vector3(0,0,0);
			walkSpeed = 10;
			runSpeed = 15;
			jumpPower = 5;
		}
		bool run = Input.GetKey(KeyCode.LeftShift);
		if(run){
			forse *= runSpeed;
		}
		else{
			forse *= walkSpeed;
		}
		if(!isGrounded){
			forse = forse * 0.6f;
			forse.y = GetComponent<Rigidbody>().velocity.y;
		}
		if(isGrounded && Input.GetKey(KeyCode.Space)){
			forse.y = jumpPower;
		}

		if(forse!=Vector3.zero)
			GetComponent<Rigidbody>().velocity = forse;
	}
}