using UnityEngine;
using System.Collections.Generic;


public class InventoryItem
{
    public int ID;
    public string Name;
    public int Value;

    public InventoryItem(int id, string name, int value)
    {
        ID = id;
        Name = name;
        Value = value;
    }
}
