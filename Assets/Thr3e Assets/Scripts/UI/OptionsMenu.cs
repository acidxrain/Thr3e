using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{

    public GameObject Options;
    public bool ShowOptions;


	// Use this for initialization
	void Start ()
    {
        Options.SetActive(false);
        ShowOptions = false;
	}

    void Update()
    {
        if (ShowOptions == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Options.SetActive(false);
                ShowOptions = false;
            }
        }
    }

    public void ShowOptionsMenu()
    {
        Options.SetActive(true);
        ShowOptions = true;
    }
}
