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

   
}

[CustomEditor(typeof(ShopDevTool))]
public class ShopDevToolEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ShopDevTool devTool = (ShopDevTool)target;

        if (devTool.shopManager == null)
        {
            EditorGUILayout.HelpBox("Assign ShopManager reference in the inspector!", MessageType.Warning);
            return;
        }

        GUILayout.Space(10);

        GUILayout.Label("Add New Item:");
        devTool.newItemName = EditorGUILayout.TextField("Item Name:", devTool.newItemName);
        devTool.newItemPrice = EditorGUILayout.IntField("Item Price:", devTool.newItemPrice);

        if (GUILayout.Button("Add Item"))
        {
            devTool.AddNewItem();
        
        }

     
    }
}
