using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public new string name = "new Item";

    public string type;

    //0 - low, 1 - medium, 2 - good, 3 - HIGH
    public int Quality;

    public int expiry;

    public float price;

    public Sprite image = null;

}
