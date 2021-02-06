
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
    public Text itemQuality;
    public Text NoInCart;
    public int i;
    [HideInInspector]
    public IsleInteract triggerArea;
    static float[] truePrice = new float[3];
    public GameObject DiscountPanel;

    private Item item;
    //setting array number
    //private int i;

    public void itemIsleSet()
    { 

        switch (i)
        {
            case 0:
                item = triggerArea.item[0];
                break;
            case 1:
                item = triggerArea.item[1];
                break;
            case 2:
                item = triggerArea.item[2];
                break;
        }

        if (triggerArea.Discount[i] == true)
        {
            DiscountPanel.SetActive(true);
            truePrice[i] = (item.price * 4 / 5);
        }
        else
        {
            DiscountPanel.SetActive(false);
            truePrice[i] = item.price;
        }   

        inventory = Inventory.instance;
        itemName.text = item.name;
        itemExp.text = "Exp in:" + item.expiry;
        itemPrice.text = "Price:" + truePrice[i];
        itemQuality.text = "Quality: " + item.Quality;
        itemImage.sprite = item.image;
        itemLeftDisplay.text = "Item left:" + triggerArea.quantity[i];
        NoInCart.text = "In Cart:" + inventory.quantity(item);
    }


    public void ItemAddtoCart()
    {

        if (truePrice[i] <= FindObjectOfType<GameManager>().currentGold)
        {
            if (triggerArea.quantity[i] > 0)
            {
                FindObjectOfType<GameManager>().RemoveGold(truePrice[i]);
                if (inventory.Add(item)) triggerArea.quantity[i] -= 1; ;
                itemLeftDisplay.text = "Item left:" + triggerArea.quantity[i];
                NoInCart.text = "In Cart:" + inventory.quantity(item);

            }
            else
            {
                Debug.Log("No Item Left");
                FindObjectOfType<AudioManager>().PlaySFX("NotEnoughMoney");
            }
        }
        else
        {
            Debug.Log("you poor soul");
            FindObjectOfType<AudioManager>().PlaySFX("NotEnoughMoney");
        }

    }

        public void ItemRemovefromCart()
    {
        //triggerArea.quantity[i] < triggerArea.returnMax(i)
        if (inventory.quantity(item)>0)
        {
            FindObjectOfType<GameManager>().AddGold(truePrice[i]);
            triggerArea.quantity[i] += 1;
            inventory.Remove(item);
            itemLeftDisplay.text = "Item left:" + triggerArea.quantity[i];
            NoInCart.text = "In Cart:" + inventory.quantity(item);


        }
    }

}
