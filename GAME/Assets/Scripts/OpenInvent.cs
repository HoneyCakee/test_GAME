using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInvent : MonoBehaviour {

	public GameObject inventory;

	void Start () {
		
		inventory.SetActive (false);
	}

	void Update () {

		if (Input.GetMouseButtonDown (0)) {

			if (inventory.activeSelf) {
				inventory.SetActive (false);
			} else {
				inventory.SetActive (true);
			}
		}
	}
}
