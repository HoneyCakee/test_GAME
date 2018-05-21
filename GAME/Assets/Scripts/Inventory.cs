using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public GameObject IamgeNameObj;
	public Text TextNameObj;


	public GameObject PanelInventory;
	public GameObject InventScrollInstance;
	public GameObject InventPanelInfo;
	public Text IventoryNameObj;
	public Image InventImageObj;
	public Text InventNumCurObjs;

	public GameObject ButtonDel;

	GameObject flashlight;
	GameObject matches;

	void Start () {
		

	}
	

	void FixedUpdate () {

		if (IamgeNameObj.activeSelf) {

			IamgeNameObj.SetActive (false);
		}
		RaycastHit hit;

		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 50)) {
			StatsObj statsObj = hit.collider.GetComponent<StatsObj> ();
			if (statsObj != null) {
				IamgeNameObj.SetActive (true);
				TextNameObj.text = statsObj.NameObj;

				if (Input.GetKeyUp (KeyCode.E)) {
					if (hit.collider.tag == "Flashlights") {
						int flashlights = GetComponent<PlayerStats> ().Flashlights;
						if (flashlights == 0) {
							Button butObj = hit.collider.GetComponent<StatsObj> ().ButtonObjInfo;
							GameObject obj = Instantiate (butObj.transform.gameObject);
							obj.transform.SetParent (InventScrollInstance.transform);
							PlayerStats playerStats = GetComponent<PlayerStats> ();
							playerStats.Flashlights += hit.collider.GetComponent<StatsObj> ().CurNumObj;
							Destroy (hit.collider.gameObject);
						} else {
							PlayerStats playerStats = GetComponent<PlayerStats> ();
							playerStats.Flashlights += hit.collider.GetComponent<StatsObj> ().CurNumObj;
							Destroy (hit.collider.gameObject);
						}
					}

					if (Input.GetKeyUp (KeyCode.E)) {
						if (hit.collider.tag == "Matches") {
							int matches = GetComponent<PlayerStats> ().Matches;
							if (matches == 0) {
								Button butObj = hit.collider.GetComponent<StatsObj> ().ButtonObjInfo;
								GameObject obj = Instantiate (butObj.transform.gameObject);
								obj.transform.SetParent (InventScrollInstance.transform);
								PlayerStats playerStats = GetComponent<PlayerStats> ();
								playerStats.Matches += hit.collider.GetComponent<StatsObj> ().CurNumObj;
								Destroy (hit.collider.gameObject);
							} else {
								PlayerStats playerStats = GetComponent<PlayerStats> ();
								playerStats.Matches += hit.collider.GetComponent<StatsObj> ().CurNumObj;
								Destroy (hit.collider.gameObject);
							}
						}
					}
				}
			}
		}

	if (Input.GetKeyDown (KeyCode.Tab)) {
			PanelInventory.SetActive (true);	
			Time.timeScale = 0;

			GameObject M1 = GameObject.Find ("PlayerMain");
			MouseLook MS1 = M1.GetComponent<MouseLook> ();
			MS1.enabled = false;

			GameObject M2 = GameObject.Find ("Camera");
			MouseLook MS2 = M2.GetComponent<MouseLook> ();
			MS2.enabled = false;

		}
	}
		public void ExitInventory(){

			PanelInventory.SetActive(false);
			Time.timeScale = 1;

			GameObject M1 = GameObject.Find ("PlayerMain");
			MouseLook MS1 = M1.GetComponent<MouseLook> ();
			MS1.enabled = true;


			GameObject M2 = GameObject.Find ("Camera");
			MouseLook MS2 = M2.GetComponent<MouseLook> ();
			MS2.enabled = true;
			
	
	}

	public void ClickButtonsInvent(Button but){
		InventPanelInfo.SetActive (true);
		IventoryNameObj.text = but.GetComponent<StatsObj> ().NameObj;
		InventImageObj.sprite = but.GetComponent<StatsObj > ().SpriteObj;
		int idObj = but.GetComponent <StatsObj> ().IdObj;
		if (idObj == 1) {
			InventNumCurObjs.text = GetComponent<PlayerStats> ().Flashlights.ToString();

		}

		if (idObj == 2) {
			InventNumCurObjs.text = GetComponent<PlayerStats> ().Matches.ToString();

		}

		DeleteInventObj deleteInventObj = ButtonDel.GetComponent<DeleteInventObj> ();
		deleteInventObj.ButtonObjDel = but;

	}

	public void DeleteInventObj (Button but){
		Button obj = but.GetComponent<DeleteInventObj>().ButtonObjDel;
		int id = obj.GetComponent<StatsObj> ().IdObj;
		PlayerStats stats = GetComponent<PlayerStats> ();

		if (id == 1) {
			flashlight = GameObject.FindWithTag("Flashlights");
			Instantiate (flashlight);
			flashlight.transform.position = transform.position + transform.forward + transform.up;
			stats.Flashlights -= 1;
			InventNumCurObjs.text = GetComponent<PlayerStats> ().Flashlights.ToString();
			if (stats.Flashlights == 0){
				IamgeNameObj.SetActive (false);
				Destroy (obj.gameObject);
			}
		}

		if (id == 2) {
			matches = GameObject.FindWithTag("Matches");
			Instantiate (matches);
			matches.transform.position = transform.position + transform.forward + transform.up;
			stats.Matches -= 1;
			InventNumCurObjs.text = GetComponent<PlayerStats> ().Matches.ToString();
			if (stats.Matches == 0){
				IamgeNameObj.SetActive (false);
				Destroy (obj.gameObject);
			}
		}
	}
}
