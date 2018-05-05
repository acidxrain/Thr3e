using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllocationText : MonoBehaviour
{

    public GUIStyle myStyle;
    public PlayerExperience pxp;

    private void Start()
    {
    }

    void Update()
    {
    }

    private void OnGUI()
    {
        GUI.Button(new Rect(310, 33, 150, 20), pxp.currentLevel.ToString(), myStyle);
        GUI.Button(new Rect(305, 845, 150, 20), pxp.currentStatPoints.ToString(), myStyle);
    }
}