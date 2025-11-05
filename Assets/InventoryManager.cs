using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeInventory()
    {
        string[] items = { "Sword", "Shield", "Potion", "Key", "Food", "SpellBook" };

        for (int i = 0; i < 5; i++)
        {
            int randomID = Random.Range(1000, 9999);
            string RandomName = items[Random.Range(0, items.Length)];
            int randomValue = Random.Range(0, 11);

            InventoryItem newItem = new InventoryItem(randomID, RandomName, randomValue);
            inventory.Add(newItem);
        }

        foreach (InventoryItem item in inventory)
        {
            Debug.Log($"Item: {item.Name} | ID: {item.ID} | Value: {item.Value}");
        }
    }
}
