using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class StatsObj : MonoBehaviour {

	public string NameObj;
	public Sprite SpriteObj;
	public Button ButtonObjInfo;
	public int CurNumObj;
	public int IdObj;


	void Start () {
		
	}
	

	void FixedUpdate () {

		RaycastHit hit;
		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 25)) {
			Debug.Log (hit.collider.tag);
		}
		
	}
}
