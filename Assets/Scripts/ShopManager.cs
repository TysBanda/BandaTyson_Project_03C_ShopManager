using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private Dictionary<string, int> itemPrices = new Dictionary<string, int>();

    private void Start()
    {
        // Initialize item prices
        InitializeItems();
    }

    private void InitializeItems()
    {
        // Set initial item prices
        itemPrices.Add("Item1", 10);
        itemPrices.Add("Item2", 20);
        itemPrices.Add("Item3", 30);
    }

    // Method to add a new item to the shop
    public void AddItem(string itemName, int price)
    {
        if (!itemPrices.ContainsKey(itemName))
        {
            itemPrices.Add(itemName, price);
        }
        else
        {
            Debug.LogWarning("Item " + itemName + " already exists!");
        }
    }

    // Method to remove an item from the shop
    public void RemoveItem(string itemName)
    {
        if (itemPrices.ContainsKey(itemName))
        {
            itemPrices.Remove(itemName);
        }
        else
        {
            Debug.LogWarning("Item " + itemName + " does not exist!");
        }
    }

    // Method to update the price of an existing item
    public void UpdateItemPrice(string itemName, int newPrice)
    {
        if (itemPrices.ContainsKey(itemName))
        {
            itemPrices[itemName] = newPrice;
        }
        else
        {
            Debug.LogWarning("Item " + itemName + " does not exist!");
        }
    }

    // Method to get the prices of all items
    public Dictionary<string, int> GetItemPrices()
    {
        return itemPrices;
    }
}
