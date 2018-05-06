using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInt : MonoBehaviour {

	public GameObject UIInterface;


	void Start () {
		
	}
	

	void Update () {
		
		if (Input.GetKeyDown (KeyCode.I))
		{
			if (UIInterface.activeSelf) {
				UIInterface.SetActive (false);	
		} else 
		{
				UIInterface.SetActive (true);	
		}
		

		}
	}
}
