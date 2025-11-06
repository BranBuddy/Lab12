using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Linq;
using System;
using UnityEditor.EditorTools;

public class InventoryManager : MonoBehaviour
{
    [Tooltip("Select this before runtime")] public bool SortListByID = false;
    private bool listSorted;
    public List<InventoryItem> inventory = new List<InventoryItem>();
    string[] items = { "Sword", "Shield", "Potion", "Key", "Food", "SpellBook" };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        InitializeInventory();
        LinearSearchByName();

        if (inventory.Count > 0)
        {
            int targetID = inventory[0].ID;
            InventoryItem found = BinarySearchByID(targetID);

            if (found != null)
            {
                Debug.Log($"Found Item by ID {targetID}: {found.Name} (Value: {found.Value})");
            }
            else
            {
                Debug.Log($"Item with ID {targetID} not found");
            }
        }

        if (inventory.Count > 0)
        {
            int[] valueArr = inventory.Select(i => i.Value).ToArray();

            var sorted = QuickSort(valueArr, 0, valueArr.Length);

            foreach (var items in sorted)
            {
                Debug.Log(items);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeInventory()
    {

        for (int i = 0; i < 5; i++)
        {
            int randomID = UnityEngine.Random.Range(1000, 9999);
            string RandomName = items[UnityEngine.Random.Range(0, items.Length)];
            int randomValue = UnityEngine.Random.Range(0, 11);

            InventoryItem newItem = new InventoryItem(randomID, RandomName, randomValue);
            inventory.Add(newItem);
        }

        // sorts inventory by id
        if (SortListByID)
        {
            inventory = inventory.OrderBy(s => s.ID).ToList();
            listSorted = true;
        }

        foreach (InventoryItem item in inventory)
        {
            Debug.Log($"Item: {item.Name} | ID: {item.ID} | Value: {item.Value}");
        }
                
    }

    void LinearSearchByName()
    {

        string RandomChosenName = items[UnityEngine.Random.Range(0, items.Length)];
        foreach (InventoryItem item in inventory)
        {
            if (RandomChosenName == item.Name)
            {
                Debug.Log($"Searching for Item: {item.Name}");
                Debug.Log($"Found Item! Item: {item.Name} | ID: {item.ID} | Value: {item.Value}");
            }
        }
    }

    // if the list is sorted them the system will search by id
    InventoryItem BinarySearchByID(int targetID)
    {
        int left = 0;
        int right = inventory.Count - 1;

        if (listSorted)
        {
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int midID = inventory[mid].ID;

                if (midID == targetID)
                {
                    return inventory[mid];
                }
                else if (midID < targetID)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }
        else
        {
            Debug.LogWarning("Sort List by id is OFF");
        }
        return null;
    }
    public static void Swap(int[] arr, int first, int last)
    {
        int temp = arr[first];
        arr[first] = arr[last];
        arr[last] = temp;
    }

    public static int Partion(int[] arr, int first, int last)
    {
        int pivot = arr[first];
        int swapIndex = first;

        for (int i = first + 1; i < last; i++)
        {
            if (arr[i] < pivot)
            {
                swapIndex++;
                Swap(arr, i, swapIndex);
            }
        }

        Swap(arr, first, swapIndex);
        return swapIndex;
    }
    
    public static int[] QuickSort(int[] arr, int first, int last){
        if (first < last)
        {
            int pivot = Partion(arr, first, last);
            QuickSort(arr, first, pivot);
            QuickSort(arr, pivot + 1, last);
        }
        return arr;
    }
}
