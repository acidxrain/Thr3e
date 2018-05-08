using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject inventoryMenu;
    private bool isShowing;

    private void Start()
    {
        inventoryMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isShowing = !isShowing;
            inventoryMenu.SetActive(isShowing);
        }
    }
}