using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objective : MonoBehaviour
{
    // Start is called before the first frame update
    public Item item;
    public int quantity;
    public Text itemName;
    public Image checkbox;
    public bool Check = false;


    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        itemName.text = item.name + " = " + quantity;
    }

    // Update is called once per frame
    void Update()
    {
        Check = objectiveMet();
        if (Check)
        {
            checkbox.enabled = true;
        }
        else checkbox.enabled = false;
    }

    bool objectiveMet()
    {
        if (inventory.quantity(item) == quantity)
            return true;

        else return false;

    }
}
