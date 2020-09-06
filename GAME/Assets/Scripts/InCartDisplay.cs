using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InCartDisplay : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject cartDisplay;
    public Text NoOfItems;
    Inventory inventory;

    InventorySlot[] slots;

    int incartCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        cartDisplay.SetActive(false);
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
