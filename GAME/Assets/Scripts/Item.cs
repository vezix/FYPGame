using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public new string name = "new Item";

    public int expiry;

    public float price;

    public Sprite image = null;

}
