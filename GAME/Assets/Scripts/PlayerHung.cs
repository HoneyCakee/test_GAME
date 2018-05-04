using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerHung : MonoBehaviour {

	public float currentHungry = 100;
	public float time = 1f;

	public Sprite full;
	public Sprite H3;
	public Sprite H2;
	public Sprite H1;
	public Sprite empty;


	private float minHungry = 0;
	private float maxHungry = 100;

	Image Image;


	void Start () {
		Image = GetComponent<Image> ();
		StartCoroutine (hungry (5));
	}


	void Update () {

		}

	IEnumerator hungry (float h){
		while (currentHungry >= minHungry) {

			yield return new WaitForSeconds (time);
			currentHungry -= h;
			if (currentHungry == 70) {
				Image.sprite = H3;
			}

			if (currentHungry == 50) {
				Image.sprite = H2;
			}

			if (currentHungry == 25) {
				Image.sprite = H1;
			}

			if (currentHungry == 0) {
				Image.sprite = empty;
			}
			}
		}
}