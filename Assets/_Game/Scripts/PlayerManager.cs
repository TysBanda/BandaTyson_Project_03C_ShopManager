using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int money = 100;
    public ShopManager shopManager;

    public void BuyItem(string itemName)
    {
        Debug.Log("Attempting to buy item: " + itemName); 

        int itemPrice = shopManager.GetItemPrice(itemName); 
        if (itemPrice == -1)
        {
            Debug.LogError("Item not found in the shop!");
            return;
        }
    

        if (money >= itemPrice)
        {
            money -= itemPrice; 
            Debug.Log("You bought " + itemName + " for " + itemPrice + " money.");
      
        }
        else
        {
            Debug.LogWarning("Not enough money to buy " + itemName + ".");
        }
    }


    public void AddMoney(int amount)
    {
        money += amount;
    }


    public void RemoveMoney(int amount)
    {
        money -= amount;
    }
}
