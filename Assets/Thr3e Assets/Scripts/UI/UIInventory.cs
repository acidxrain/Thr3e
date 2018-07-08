using UnityEngine;

public class UIInventory : MonoBehaviour
{

    public GameObject inventoryMenu;
    public GameObject inventory;
    private bool isShowing;
    private bool invShowing;

    private void Start()
    {
        inventoryMenu.SetActive(false);
        inventory.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isShowing = !isShowing;
            invShowing = !invShowing;
            inventoryMenu.SetActive(isShowing);
            inventory.SetActive(invShowing);
        }
    }
}