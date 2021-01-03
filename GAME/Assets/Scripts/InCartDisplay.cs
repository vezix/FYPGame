using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InCartDisplay : MonoBehaviour
{
    //Make Sure GameObject is set Active first before anything to ensure no bug occurs.

    public Transform itemsParent;
    public GameObject cartDisplay;
    public Text NoOfItems;
    Inventory inventory;
    public PlayerController PController;


    InventorySlot[] slots;

    int incartCount = 0;

    void Start()
    {
        cartDisplay.SetActive(false);
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
            incartCount = inventory.items.Count;
            NoOfItems.text = "Number of Items in cart = " + incartCount.ToString();
        }
    }

    public void closePanel()
    {
        cartDisplay.SetActive(false);
        FindObjectOfType<AudioManager>().PlaySFX("Inventory");
        PController.enabled = true;
        //Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
