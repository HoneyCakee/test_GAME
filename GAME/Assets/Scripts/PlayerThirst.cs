using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerThirst : MonoBehaviour {

	public float currentThirst = 100;
	public float time = 1f;

	public Sprite full;
	public Sprite H3;
	public Sprite H2;
	public Sprite H1;
	public Sprite empty;


	private float minThirst = 0;
	private float maxThirst = 100;

	Image Image;


	void Start () {
		Image = GetComponent<Image> ();
		StartCoroutine (thirst (5));
	}


	void Update () {

	}

	IEnumerator thirst (float h){
		while (currentThirst >= minThirst) {

			yield return new WaitForSeconds (time);
			currentThirst -= h;
			if (currentThirst == 70) {
				Image.sprite = H3;
			}

			if (currentThirst == 50) {
				Image.sprite = H2;
			}

			if (currentThirst == 25) {
				Image.sprite = H1;
			}

			if (currentThirst == 0) {
				Image.sprite = empty;
			}
		}
	}
}
