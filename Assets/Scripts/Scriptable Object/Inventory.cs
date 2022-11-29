using UnityEngine;
using System.Collections.Generic;
using BuildingBlocks.DataTypes;

[CreateAssetMenu(menuName = "Inventory/Inventory", fileName = "Inventory.asset")]
[System.Serializable]
public class Inventory : ScriptableObject
{
    [SerializeField] private InspectableDictionary<string,TextIcon> inventory = new InspectableDictionary<string,TextIcon>();
    public TextIcon this[string key] {
        get 
        {
            return inventory[key];
        }
        set
        {
            inventory[key] = value;
        }
    }

    public TextIcon this[int key] {
        get 
        {
            return inventory[key];
        }
        set
        {
            inventory[key] = value;
        }
    }
    

    public int GetLength()
    {
        return inventory.Count;
    }
}
