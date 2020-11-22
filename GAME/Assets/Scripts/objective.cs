using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objective : MonoBehaviour
{
    // Start is called before the first frame update
    public Item item;
    public int quantity;
    public int expiry;
    public Text itemName;
    public Image checkbox;
    public bool Check = false;

    public bool checkitemName;
    public bool checkitemType;
    public bool checkitemPrice;


    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        itemName.text = item.name + " = " + quantity;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkitemName)
        {
            Check = objectiveName();
        }
        if (checkitemType)
        {
            Check = objectiveType();
        }

        if (Check)
        {
            checkbox.enabled = true;
        }
        else checkbox.enabled = false;
    }

    bool objectiveName()
    {
        if (inventory.quantity(item) == quantity)
            return true;
        else return false;
    }

    bool objectiveType()
    {
        if (inventory.Typequantity(item) == quantity)
            return true;
        else return false;
    }
}
