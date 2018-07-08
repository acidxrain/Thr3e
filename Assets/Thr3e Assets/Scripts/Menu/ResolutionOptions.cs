using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOptions : MonoBehaviour {

    private const string RESOLUTION_PREF_KEY = "resolution";

    [SerializeField]
    private Text resolutionText;
    private Resolution[] resolutions;
    private int currentResolutionIndex = 0;
    public Toggle toggle;
    public bool screenModeBool;

    // Use this for initialization
    void Start ()
    {
        resolutions = Screen.resolutions;
        currentResolutionIndex = PlayerPrefs.GetInt(RESOLUTION_PREF_KEY, 0);
        SetResolutionText(resolutions[currentResolutionIndex]);
    }

    private void SetResolutionText(Resolution resolution)
    {
        resolutionText.text = resolution.width + "x" + resolution.height;
    }

    public void SetNextResolution()
    {
        currentResolutionIndex = GetNextWrappedIndex(resolutions, currentResolutionIndex);
        SetResolutionText(resolutions[currentResolutionIndex]);
    }

    public void SetPreviousResolution()
    {
        currentResolutionIndex = GetPreviousWrappedIndex(resolutions, currentResolutionIndex);
        SetResolutionText(resolutions[currentResolutionIndex]);
    }

    public void SetFullScreen()
    {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        Screen.fullScreen = !toggle.isOn;
        //Screen.fullScreen = fullscreenToggleComponent.isOn;
        //Debug.Log(fullscreenToggleComponent.isOn);
        //Screen.fullScreenMode = (fullscreenToggleComponent.isOn) ? FullScreenMode.FullScreenWindow : FullScreenMode.ExclusiveFullScreen;
        //Debug.Log(Screen.fullScreenMode);
    }

    private void SetAndApplyResolution(int newResolutionIndex)
    {
        currentResolutionIndex = newResolutionIndex;
        ApplyCurrentResolution();
    }

    private void ApplyCurrentResolution()
    {
        ApplyResolution(resolutions[currentResolutionIndex]);
    }

    private void ApplyResolution(Resolution resolution)
    {
        SetResolutionText(resolution);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt(RESOLUTION_PREF_KEY, currentResolutionIndex);
    }
	
    private int GetNextWrappedIndex<T>(IList<T> collection, int currentIndex)
    {
        if (collection.Count < 1) return 0;
        return (currentIndex + 1) % collection.Count;
    }

    private int GetPreviousWrappedIndex<T>(IList<T> collection, int currentIndex)
    {
        if (collection.Count < 1) return 0;
        if ((currentIndex - 1) < 0) return collection.Count - 1;
        return (currentIndex - 1) % collection.Count;
    }

    public void ApplyChanges()
    {
        SetAndApplyResolution(currentResolutionIndex);
    }
}
