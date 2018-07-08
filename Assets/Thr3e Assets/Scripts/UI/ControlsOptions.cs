using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsOptions : MonoBehaviour
{
    public GameObject VideoOptionsMenu;
    public GameObject AudioOptionsMenu;
    public GameObject ControlsOptionsMenu;

    private void Start()
    {
        ControlsOptionsMenu.SetActive(false);
    }

    public void ShowControlsOptions()
    {
        ControlsOptionsMenu.SetActive(true);
        VideoOptionsMenu.SetActive(false);
        AudioOptionsMenu.SetActive(false);
    }
}
