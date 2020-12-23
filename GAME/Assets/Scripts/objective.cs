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
    [HideInInspector]
    public bool Check = false;

    public bool checkitemName = false;
    public bool checkitemType = false;
    public bool checkitemTypePrice = false;
    public bool checkingitemTypeExp = false;
    public bool checkitemQuality = false;

    //private int reachedQuality = 0;



    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        if (checkitemQuality)
            itemName.text = item.name + ", >= " + quantity;
        else
        itemName.text = item.name + ", need " + quantity;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkitemQuality)
        {
            Check = QualityCheck();
        }

        if (checkitemName)
        {
            Check = objectiveName();
        }
        if (checkitemType)
        {
            Check = objectiveType();
        }

        if (checkingitemTypeExp)
        {
            Check = objectiveTypeExp();
        }

        if (checkitemTypePrice)
        {
            Check = objectiveTypePrice();
        }

        if (Check)
        {
            checkbox.enabled = true;
        }
        else checkbox.enabled = false;
    }

    bool QualityCheck()
    {
        if (inventory.quality(item) >= quantity)
            return true;
        else return false;
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

    bool objectiveTypePrice()
    {
        if (inventory.TypePriceQuantity(item) == quantity)
            return true;
        else return false;
    }

    bool objectiveTypeExp()
    {
        if (inventory.TypeExpQuantity(item) == quantity)
            return true;
        else return false;
    }
}
