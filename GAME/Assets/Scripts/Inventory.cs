using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	List<Item>list;
	public GameObject inventory;
	public GameObject UIInterface;
	public GameObject cont;

	void Start () {
		list = new List<Item>();
	}

	void Update () {

		if (Input.GetMouseButton (1)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Item item = hit.collider.GetComponent<Item> ();
				if (item != null) {
					list.Add (item);
					Destroy (hit.collider.gameObject);
				}
			}
		}

	if (Input.GetKeyDown (KeyCode.F)) {
		
			if (inventory.activeSelf) {
				inventory.SetActive (false);

				for (int i = 0; i < inventory.transform.childCount; i++) {
					if (inventory.transform.GetChild (i).transform.childCount > 0) {
						Destroy (inventory.transform.GetChild (i).transform.GetChild (0).gameObject);
					}
				}

			} else {
				inventory.SetActive (true);
				int count = list.Count;
				for (int i = 0; i < count; i++) {
					Item it = list [i];
					if (inventory.transform.childCount >= i) {
						GameObject img = Instantiate (cont);
						img.transform.SetParent (inventory.transform.GetChild (i).transform);
						img.GetComponent<Image> ().sprite = Resources.Load<Sprite> (it.icon);
						img.GetComponent<Drag> ().item = it;


					} else {
						break;
					}
				}
			}
		}

	}


//void remove (Drag drag){
		//if (drug.item.type == "food") {
		
	//	}
	//	}
	void remove (Drag drag){
		Item it = drag.item;
		GameObject newo = Instantiate<GameObject> (Resources.Load<GameObject> (it.prefab));
		newo.transform.position = transform.position + transform.forward + transform.up;
		list.Remove (it);
		Destroy(drag.gameObject);

	}
}
