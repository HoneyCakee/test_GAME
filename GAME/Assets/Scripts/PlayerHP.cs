using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {

	public PlayerHung PlayerHung;
	public PlayerThirst PlayerThirst;
	public float maxhp;
	public float minhp;
	public float hp;
	public Image slide;

	public float time = 2.0f;


	void Start () {
		slide = GetComponent<Image> ();
		maxhp = 1f;
		minhp = 0f;
		hp = maxhp;

		StartCoroutine (hungryWait (0.10f));
		StartCoroutine (thirstWait (0.13f));


	}
		

	void Update () {
		if (hp > maxhp) {
			hp = maxhp;
		}

		if (hp < 0) {
			hp = 0;
		}
	}



	IEnumerator hungryWait (float h)
	{
		while (true)
		{
			if(PlayerHung.currentHungry == 0f && hp > minhp)
			{              
				hp -= h;
				slide.fillAmount = hp;
				yield return new WaitForSeconds (time);
			}
			yield return null;
		}
	}

	IEnumerator thirstWait (float t)
	{
		while (true)
		{
			if(PlayerThirst.currentThirst == 0f && hp > minhp)
			{              
				hp -= t;
				slide.fillAmount = hp;
				yield return new WaitForSeconds (time);
			}
			yield return null;
		}
	}

}
