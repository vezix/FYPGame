using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
 
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChangedCallback;

    public int space = 20;

    [HideInInspector] public List<Item> items = new List<Item>();
    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }
        items.Add(item);

        if(onItemChangedCallback != null)
        onItemChangedCallback.Invoke();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public bool CheckForItem(Item wantedItem)
    {
        if (items.Contains(wantedItem))
        {
            return true;
        }
        else return false;
    }

    public int quantity(Item item)
    {
        int a=0;
        for (int i=0; i < items.Count; i++)
        {
            if (items[i] == item)
            {
                a++ ;
            }
        }
        return a;
    }


}
