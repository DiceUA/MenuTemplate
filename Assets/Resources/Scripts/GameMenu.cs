using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {

	[SerializeField]
	private List<GameObject> menus;
	Dropdown dp;
	[SerializeField]
	Dropdown dropdown;


	void Start ()
	{
		menus = new List<GameObject> ();
		// Add all menus in list
		menus.AddRange (GameObject.FindGameObjectsWithTag("Menu"));
		// Hide all menus except main one
		foreach (var item in menus) {
			if (item.name != "MainMenu") {
				item.SetActive (false);
			}
		}

		// Get resolutions to string
		// and fill dropdown options
		List<string> listS = new List<string>();
		dropdown = GameObject.Find("Dropdown").GetComponent<Dropdown>();
		foreach (var item in Screen.resolutions) {
			//if((item.width == 1024 || item.width == 1280 || item.width == 1440 || item.width == 1600 || item.width == 1920))
			listS.Add (item.width + " x " + item.height);
		}
		// Get current resolution to string like in list
		// so we can now compare list items
		string currentResolution = Screen.currentResolution.width + " x " + Screen.currentResolution.height;
		dropdown.options.Clear ();
		dropdown.AddOptions (listS);
		// Set dropdown value to correct resolution
		for (int i = 0; i < listS.Count; i++) {
			if (listS [i] == currentResolution)
				dropdown.value = i;
		}

		//Установим наблюдение за изменениями в дропдауне
		//dropdown.onValueChanged.AddListener (delegate { SetNewResolution();});	

		Debug.Log (currentResolution);
		Debug.Log ("Simpe text");

	}

	void Update ()
	{
		
	
	
	}

	// Use on Apply Button pressed to change screen resolution
	// and set fullscreen
	public void SetNewResolution()
	{
		// Set new resolution
		int width = Screen.resolutions [dropdown.value].width;
		int height = Screen.resolutions [dropdown.value].height;
		Screen.SetResolution (width, height, Screen.fullScreen);

		// Set fullscreen if checkbox is checked
		if (GameObject.Find ("Toggle").GetComponent<Toggle> ().isOn)
			Screen.fullScreen = true;
		else
			Screen.fullScreen = false;

		//Debug.Log (GameObject.Find ("Toggle").GetComponent<Toggle> ().isOn);
		//Debug.Log (width + " fullscreen: " + Screen.fullScreen);
	}

	public void SetFullscreen(bool value)
	{
		Debug.Log (value);
		//Screen.fullScreen = value;
	}

	void OnMouseOver ()
	{
		if (gameObject.GetComponentInChildren<Text> () != null)
			gameObject.GetComponentInChildren<Text> ().color = Color.red;
	}

}
