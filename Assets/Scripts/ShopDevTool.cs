using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShopDevTool : MonoBehaviour
{
    public ShopManager shopManager;


    public string newItemName;
    public int newItemPrice;

    private void Start()
    {
        if (shopManager == null)
        {
            Debug.LogError("ShopManager reference not set in ShopDevTool!");
        }
    }


    public void AddNewItem()
    {
        if (string.IsNullOrEmpty(newItemName))
        {
            Debug.LogError("New item name cannot be empty!");
            return;
        }

        shopManager.AddItem(newItemName, newItemPrice);
        newItemName = ""; 
        newItemPrice = 0;
    }


    public void RemoveItem(string itemName)
    {
        shopManager.RemoveItem(itemName);
    }


    public void UpdateItemPrice(string itemName, int newPrice)
    {
        shopManager.UpdateItemPrice(itemName, newPrice);
    }
}

[CustomEditor(typeof(ShopDevTool))]
public class ShopDevToolEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ShopDevTool devTool = (ShopDevTool)target;

        GUILayout.Space(10);

        GUILayout.Label("Add New Item:");
        devTool.newItemName = EditorGUILayout.TextField("Item Name:", devTool.newItemName);
        devTool.newItemPrice = EditorGUILayout.IntField("Item Price:", devTool.newItemPrice);

        if (GUILayout.Button("Add Item"))
        {
            devTool.AddNewItem();
        }

        GUILayout.Space(10);

        GUILayout.Label("Remove Item:");
        foreach (KeyValuePair<string, int> item in devTool.shopManager.GetItemPrices())
        {
            if (GUILayout.Button("Remove " + item.Key))
            {
                devTool.RemoveItem(item.Key);
            }
        }

        GUILayout.Space(10);

        GUILayout.Label("Update Item Prices:");
        foreach (KeyValuePair<string, int> item in devTool.shopManager.GetItemPrices())
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(item.Key);
            int newPrice = EditorGUILayout.IntField(item.Value);
            if (newPrice != item.Value)
            {
                devTool.UpdateItemPrice(item.Key, newPrice);
            }
            GUILayout.EndHorizontal();
        }
    }
}
