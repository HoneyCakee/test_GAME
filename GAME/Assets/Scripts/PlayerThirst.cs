using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerThirst : MonoBehaviour {

	public float currentThirst;
	public float time = 1f;
	private float minThirst;
	private float maxThirst;

	public Image slide;


	void Start () {

		maxThirst = 1f;
		minThirst = 0f;
		currentThirst = maxThirst;

		slide = GetComponent<Image> ();
		StartCoroutine (thirst (0.05f));
	}


	void Update () {

		if (currentThirst > maxThirst) {
			currentThirst = maxThirst;
		}

		if (currentThirst < 0) {
			currentThirst = 0;
		}

	}

	IEnumerator thirst (float h){
		while (currentThirst >= minThirst) {

			yield return new WaitForSeconds (time);
			currentThirst -= h;
			slide.fillAmount = currentThirst;
		

		}
	}
}