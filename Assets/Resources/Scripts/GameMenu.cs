using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

	Dropdown dropdown;
    [SerializeField]
    List<string> listS;
    [SerializeField]
    Text debugText;

    public GameObject mainMenu, settingsMenu, rightPanel;

    void Start ()
	{
        // Initialise main menu. If i forget to set it active in editor
        if (!mainMenu.activeInHierarchy)
            mainMenu.SetActive(true);
        listS = new List<string>();        
    }

	void Update ()
	{
			
	}

    /// <summary>
    /// Use on Apply Button pressed to change screen resolution
    /// and set fullscreen
    /// </summary>
    public void SetNewResolution()
	{
        debugText.text = "Resolution: " + Screen.resolutions[dropdown.value].width + " x " + Screen.resolutions[dropdown.value].height + " Fullscreen: " + Screen.fullScreen;
        // Set new resolution
        int width = Screen.resolutions[dropdown.value].width;
		int height = Screen.resolutions[dropdown.value].height;
		Screen.SetResolution (width, height, Screen.fullScreen);

		// Set fullscreen if checkbox is checked
		if (GameObject.Find ("Toggle").GetComponent<Toggle> ().isOn)
			Screen.fullScreen = true;
		else
			Screen.fullScreen = false;

		Debug.Log (GameObject.Find ("Toggle").GetComponent<Toggle> ().isOn);
		Debug.Log (width + " fullscreen: " + Screen.fullScreen);
	}

    #region MainMenuButtons
    public void MainMenuNewGame()
    {
        //SceneManager.LoadScene("Level01");
        Debug.Log("Not implemented yet");
        throw new NotImplementedException();
    }
    public void MainMenuLoadGame()
    {        
        Debug.Log("Not implemented yet");
        throw new NotImplementedException();
    }

    /// <summary>
    /// When button Settings pressed show settings buttons
    /// </summary>
    /// <param name="selected"></param>
    public void MainMenuSettings(bool selected)
    {
        if (selected)
        {
            settingsMenu.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(false);
        }
        else
        {
            settingsMenu.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
        }
    }

    public void MainMenuQuit()
    {
        Debug.Log("Application Quited");
        Application.Quit();        
    }

    #endregion

    
    #region SubMenu functions

    /// <summary>
    /// Hides right panel submenu
    /// </summary>
    public void SubMenuHide()
    {
        foreach (Transform item in rightPanel.transform)
        {
            item.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// This is beta function. When button clicked show options on right side
    /// </summary>
    /// <param name="obj">Gameobject that was pressed</param>
    public void SubMenu2(GameObject obj)
    {
        foreach (Transform item in rightPanel.transform)
        {
            if (item.name == obj.name)
            {
                item.gameObject.SetActive(true);

                // Need to add all cases.
                switch (item.name)
                {
                    case "Graphics":
                        ShowGraphicsSubMenu(item.gameObject); // fills with correct data dropdown resolution and toggle fullscreen                        
                        break;
                    case "Audio":
                        ShowAudioSubMenu();
                        break;
                    case "Controls":
                        ShowControlsSubMenu();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }
    #region Helper methods
    /// <summary>
    /// Show correct submenu for graphics
    /// </summary>
    /// <param name="obj">current gameobject in this panel, need to find childs Dropdown and Toggle that used to set resolution and fullscreen</param>
    private void ShowGraphicsSubMenu(GameObject obj)
    {

        // Get resolutions to string
        // to fill dropdown options        
        dropdown = obj.GetComponentInChildren<Dropdown>();

        foreach (var item in Screen.resolutions)
        {
            listS.Add(item.width + " x " + item.height);
        }
        // Get current resolution to string like in list
        // so we can now compare list items
        string currentResolution = Screen.width + " x " + Screen.height;

        dropdown.options.Clear();
        dropdown.AddOptions(listS);
        // Set dropdown value to correct resolution
        for (int i = 0; i < listS.Count; i++)
        {
            if (listS[i] == currentResolution)
                dropdown.value = i;
        }

        // Set toggle to current fullscreen ON or OFF
        obj.GetComponentInChildren<Toggle>().isOn = Screen.fullScreen;

        Debug.Log(currentResolution);
        Debug.Log("Simpe text");
    }
    /// <summary>
    /// Old function, works like previous one
    /// </summary>
    private void ShowGraphicsSubMenu()
    {

        // Get resolutions to string
        // to fill dropdown options
        dropdown = GameObject.Find("Dropdown").GetComponent<Dropdown>();
        Debug.Log(Screen.resolutions.Length);
        foreach (var item in Screen.resolutions)
        {
            //if((item.width == 1024 || item.width == 1280 || item.width == 1440 || item.width == 1600 || item.width == 1920))
            listS.Add(item.width + " x " + item.height);
        }
        // Get current resolution to string like in list
        // so we can now compare list items
        string currentResolution = Screen.width + " x " + Screen.height;

        dropdown.options.Clear();
        dropdown.AddOptions(listS);
        // Set dropdown value to correct resolution
        for (int i = 0; i < listS.Count; i++)
        {
            if (listS[i] == currentResolution)
                dropdown.value = i;
        }

        //Установим наблюдение за изменениями в дропдауне
        //dropdown.onValueChanged.AddListener (delegate { SetNewResolution();});	

        GameObject.Find("Toggle").GetComponent<Toggle>().isOn = Screen.fullScreen;


        Debug.Log(currentResolution);
        Debug.Log("Simpe text");
    }

    // Not implemented 
    private void ShowAudioSubMenu()
    {
        throw new NotImplementedException();
    }

    private void ShowControlsSubMenu()
    {
        throw new NotImplementedException();
    }
    #endregion
    #endregion


    #region Something helpful

    GameObject additionalMenu;

    public void SubMenu(bool selected)
    {
        if (selected)
        {

            additionalMenu.gameObject.SetActive(true);
            Debug.Log(additionalMenu.gameObject.name);


            // Get resolutions to string
            // to fill dropdown options
            dropdown = GameObject.Find("Dropdown").GetComponent<Dropdown>();
            Debug.Log(Screen.resolutions.Length);
            foreach (var item in Screen.resolutions)
            {
                //if((item.width == 1024 || item.width == 1280 || item.width == 1440 || item.width == 1600 || item.width == 1920))
                listS.Add(item.width + " x " + item.height);
            }
            // Get current resolution to string like in list
            // so we can now compare list items
            string currentResolution = Screen.width + " x " + Screen.height;

            dropdown.options.Clear();
            dropdown.AddOptions(listS);
            // Set dropdown value to correct resolution
            for (int i = 0; i < listS.Count; i++)
            {
                if (listS[i] == currentResolution)
                    dropdown.value = i;
            }

            //Установим наблюдение за изменениями в дропдауне
            //dropdown.onValueChanged.AddListener (delegate { SetNewResolution();});	

            GameObject.Find("Toggle").GetComponent<Toggle>().isOn = Screen.fullScreen;


            Debug.Log(currentResolution);
            Debug.Log("Simpe text");
        }
        else
        {
            additionalMenu.gameObject.SetActive(false);
        }
    }
    #endregion










}
