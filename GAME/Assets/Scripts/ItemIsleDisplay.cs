
using UnityEngine;
using UnityEngine.UI;

public class ItemIsleDisplay : MonoBehaviour
{
    Inventory inventory;

    public Text itemName;
    public Text itemExp;
    public Text itemPrice;
    public Image itemImage;
    public Text itemLeftDisplay;
    public Text NoInCart;
    public int itemnumber;
    [HideInInspector]
    public IsleInteract triggerArea;

    private Item item;
    //setting array number
    private int i;
    
    public void itemIsleSet()
    {
        switch (itemnumber)
        {
            case 1:
                item = triggerArea.item[0];
                i = 0;
                break;
            case 2:
                item = triggerArea.item[1];
                i = 1;
                break;
            case 3:
                item = triggerArea.item[2];
                i = 2;
                break;
        }

        inventory = Inventory.instance;
        itemName.text = item.name;
        itemExp.text = "Exp in:" + item.expiry.ToString();
        itemPrice.text = "Price:" + item.price.ToString();
        itemImage.sprite = item.image;
        itemLeftDisplay.text = "Item left:" + triggerArea.quantity[i];
        NoInCart.text = "In Cart:" + inventory.quantity(item);
    }


    public void ItemAddtoCart()
    {
        if (item.price <= FindObjectOfType<GameManager>().currentGold)
        {
            if (triggerArea.quantity[i] > 0)
            {
                FindObjectOfType<GameManager>().RemoveGold(item.price);
                triggerArea.quantity[i] -= 1;
                inventory.Add(item);
                itemLeftDisplay.text = "Item left:" + triggerArea.quantity[i];
                NoInCart.text = "In Cart:" + inventory.quantity(item);
            }
            else Debug.Log("No Item Left");
        }
        else Debug.Log("you poor motherfucker");
        
    }

    public void ItemRemovefromCart()
    {
        //triggerArea.quantity[i] < triggerArea.returnMax(i)
        if (inventory.quantity(item)>0)
        {
            FindObjectOfType<GameManager>().AddGold(item.price);
            triggerArea.quantity[i] += 1;
            inventory.Remove(item);
            itemLeftDisplay.text = "Item left:" + triggerArea.quantity[i];
            NoInCart.text = "In Cart:" + inventory.quantity(item);
        }
    }

}
