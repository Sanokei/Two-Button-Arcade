using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Inventory", fileName = "Inventory.asset")]
[System.Serializable]
public class Inventory : ScriptableObject
{
    [SerializeField] private TextIcon[] inventory;
    public TextIcon this[int index]
    {
        get
        {
            if (SlotEmpty(index))
                return default(TextIcon);
            return inventory[index];
        }
        set
        {
            InsertIcon(index, value);
        }
    }

    public int Count{
        get
        {
            return inventory.Length;
        }
        private set{}
    }

    /// <summary>
    /// Loads the inventory to a json file.
    /// </summary>
    /// <param name="path">The path to the json file.</param>
    
    /* Inventory START */

    /// <summary>
    /// Checks if a slot is empty.
    /// </summary>
    /// <param name="index">The index of the slot to check.</param>
    /// <returns>True if the slot is empty, false if it is not.</returns>
    public bool SlotEmpty(int index) {
        if (inventory[index] == null)
            return true;
        return false;
    }

    /// <summary>
    /// Remove an icon at an index if one exists at that index.
    /// </summary>
    /// <param name="index">The index of the icon to remove.</param>
    /// <returns>True if the icon was removed, false if it didn't exist.</returns>
    public bool RemoveIcon(int index) {
        if (SlotEmpty(index)) {
            // Nothing existed at the specified slot.
            return false;
        }

        inventory[index] = default(TextIcon);

        return true;
    }

    /// <summary>
    /// Push an icon, return the index where it was inserted. If the icon already exists, return -1
    /// </summary>
    /// <param name="icon">The icon to insert.</param>
    /// <returns>The index where the icon was inserted. If the icon already exists, return -1.</returns>
    public int PushIcon(TextIcon icon) {
        for (int i = 0; i < inventory.Length; i++) {
            if (SlotEmpty(i)) {
                inventory[i] = icon;
                return i;
            }
        }

        // Couldn't find a free slot.
        return -1;
    }

    /// <summary>
    /// Push an icon, return the index where it was inserted. If the icon already exists, return -1
    /// </summary>
    /// <param name="icon">The icon to insert.</param>
    /// <returns>The index where the icon was inserted. If the icon already exists, return -1.</returns>
    public int InsertIcon(int index, TextIcon icon) {
        if(SlotEmpty(index)){
            inventory[index] = icon;
            return index;
        }
        // Was not a free slot.
        return -1;
    }
}
