
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    Item item;
    public GameObject tooltip;
    public Text tooltipText;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.image;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item != null)
        {
            tooltip.transform.position = transform.position;
            tooltipText.text = item.name + "\nexp in: " + item.expiry + " days" + "\ntype: " +item.type + "\nQuality: " + item.Quality;
            tooltip.SetActive(true);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.SetActive(false);
    }

}
