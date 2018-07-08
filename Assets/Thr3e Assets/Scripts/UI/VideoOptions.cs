using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoOptions : MonoBehaviour
{
    public GameObject VideoOptionsMenu;
    public GameObject AudioOptionsMenu;
    public GameObject ControlsOptionsMenu;

    void Start()
    {
        VideoOptionsMenu.SetActive(false);    
    }

    public void ShowVideoOptions()
    {
        VideoOptionsMenu.SetActive(true);
        AudioOptionsMenu.SetActive(false);
        ControlsOptionsMenu.SetActive(false);
    }
}
