using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatAllocation : MonoBehaviour
{

    public GameObject statAllocationMenu;
    private bool isShowing;

    private void Start()
    {
        statAllocationMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isShowing = !isShowing;
            statAllocationMenu.SetActive(isShowing);
        }
    }
}