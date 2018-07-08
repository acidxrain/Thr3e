using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOptions : MonoBehaviour
{
    public GameObject VideoOptionsMenu;
    public GameObject AudioOptionsMenu;
    public GameObject ControlsOptionsMenu;

    private void Start()
    {
        AudioOptionsMenu.SetActive(false);
    }

    public void ShowAudioOptions()
    {
        AudioOptionsMenu.SetActive(true);
        VideoOptionsMenu.SetActive(false);
        ControlsOptionsMenu.SetActive(false);
    }

}
