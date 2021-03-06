﻿using System.Collections;
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
        FindObjectOfType<AudioManager>().PlaySFX("Buy");

        if (onItemChangedCallback != null)
        onItemChangedCallback.Invoke();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        FindObjectOfType<AudioManager>().PlaySFX("Sell");

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

    public int quality(Item item)
    {
        int a = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Quality >= item.Quality)
            {
                a++;
            }
        }
        return a;
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

    public int Typequantity(Item item)
    {
        int a = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].type == item.type)
            {
                a++;
            }
        }
        return a;
    }

    public int TypePriceQuantity(Item item)
    {
        int a = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].type == item.type && items[i].price <= item.price) 
            {
                a++;
            }
        }
        return a;
    }

    public int TypeExpQuantity(Item item)
    {
        int a = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].type == item.type && items[i].expiry >= item.expiry)
            {
                a++;
            }
        }
        return a;
    }

}
