using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LookAxe{
	Horisontal,
	Vertical
}

public class MouseLook : MonoBehaviour {

	public LookAxe axis;
	public float speed = 10;
	public float smooth = 1.4f;
	public float min = -360;
	public float max = 360;



	Vector3 final;
	void Update () {
		Vector2 delta = new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));
		if(axis == LookAxe.Horisontal){
			final.y = Mathf.Lerp(final.y,final.y+delta.x*speed,1/smooth);
			final.y = Mathf.Clamp(final.y,min,max);
		}
		if(axis == LookAxe.Vertical){
			final.x = Mathf.Lerp(final.x,final.x-delta.y*speed,1/smooth);
			final.x = Mathf.Clamp(final.x,min,max);
		} 
		final=circle(final);
		transform.localEulerAngles = final;
	}

	Vector3 circle(Vector3 vec){
		Vector3 y = vec;
		if(y.x>360)
			y.x -=360;
		if(y.x<-360)
			y.x +=360;
		if(y.y>360)
			y.y -=360;
		if(y.y<-360)
			y.y +=360;
		return y;
	}


	} 

