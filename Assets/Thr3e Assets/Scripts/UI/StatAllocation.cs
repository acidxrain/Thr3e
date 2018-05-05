using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatAllocation : MonoBehaviour
{

    public GameObject menu; // Assign in inspector
    private bool isShowing;

    private void Start()
    {
        menu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }
    }
}