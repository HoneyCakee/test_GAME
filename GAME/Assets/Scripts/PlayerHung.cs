using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerHung : MonoBehaviour {

	public float currentHungry;
	public float time = 1f;

	private float minHungry; 
	private float maxHungry; 

	public Image slide;


	void Start () {

		maxHungry = 1f;
		minHungry = 0f;
		currentHungry = maxHungry;

		slide = GetComponent<Image> ();
		StartCoroutine (hungry (0.07f));
	}


	void Update () {

		if (currentHungry > maxHungry) {
			currentHungry = maxHungry;
		}

		if (currentHungry < 0) {
			currentHungry = 0;
		}

		}

	IEnumerator hungry (float h){
		while (currentHungry > minHungry) {

			yield return new WaitForSeconds (time);
			currentHungry -= h;
			slide.fillAmount = currentHungry;


			}
		}
}