using UnityEngine;
using System.Collections.Generic;
using BuildingBlocks.DataTypes;

[CreateAssetMenu(menuName = "Inventory/Inventory", fileName = "Inventory.asset")]
[System.Serializable]
public class Inventory : ScriptableObject
{
    [SerializeField] private InspectableDictionary<string,TextIcon> inventory = new InspectableDictionary<string,TextIcon>();
}
