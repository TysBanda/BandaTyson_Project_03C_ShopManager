using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float coins = 1000;
    public float numOfItem1 = 0;
    public float numOfItem2 = 0;
    public float numOfItem3 = 0;
    private ShopManager shopManager;

    private void Start()
    {
        shopManager = GameObject.FindObjectOfType<ShopManager>();
    }

    public void buyItem(string itemName)
    {
        if (!shopManager.GetItemPrices().ContainsKey(itemName))
        {
            Debug.LogError("Item " + itemName + " does not exist in the shop!");
            return;
        }

        float itemPrice = shopManager.GetItemPrices()[itemName];

        if (coins >= itemPrice)
        {
            switch (itemName)
            {
                case "Item1":
                    numOfItem1++;
                    break;
                case "Item2":
                    numOfItem2++;
                    break;
                case "Item3":
                    numOfItem3++;
                    break;
                default:
                    Debug.LogError("Invalid item name: " + itemName);
                    return;
            }

            coins -= itemPrice;
            print(itemName + " purchased. You have " + GetNumberOfItems(itemName) + " " + itemName + " and " + coins.ToString() + " coins.");
        }
        else
        {
            print("Not enough coins");
        }
    }

    private float GetNumberOfItems(string itemName)
    {
        switch (itemName)
        {
            case "Item1":
                return numOfItem1;
            case "Item2":
                return numOfItem2;
            case "Item3":
                return numOfItem3;
            default:
                return 0;
        }
    }
}
