using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float coins = 1000;
    private Dictionary<string, float> inventory = new Dictionary<string, float>();
    private ShopManager shopManager;

    private void Start()
    {

        shopManager = FindObjectOfType<ShopManager>();


        if (shopManager == null)
        {
            Debug.LogError("ShopManager component not found in the scene.");
        }
    }

    public void BuyItem(string itemName)
    {

        if (shopManager == null)
        {
            Debug.LogError("ShopManager reference not set in PlayerManager!");
            return;
        }

 
        if (!shopManager.GetItemPrices().ContainsKey(itemName))
        {
            Debug.LogError("Item " + itemName + " does not exist in the shop!");
            return;
        }

        float itemPrice = shopManager.GetItemPrices()[itemName];

        if (coins >= itemPrice)
        {
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName]++;
            }
            else
            {
                inventory[itemName] = 1;
            }

            coins -= itemPrice;
            Debug.Log(itemName + " purchased. You have " + GetNumberOfItems(itemName) + " " + itemName + "(s) and " + coins.ToString() + " coins remaining.");
        }
        else
        {
            Debug.Log("Not enough coins to purchase " + itemName);
        }
    }

    private float GetNumberOfItems(string itemName)
    {
        return inventory.ContainsKey(itemName) ? inventory[itemName] : 0;
    }
}
