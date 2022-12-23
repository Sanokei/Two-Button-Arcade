using System.Collections.Generic;
using UnityEngine;

using SeralizedJSONSystem;
[System.Serializable]
public class InventoryPhysical : MonoBehaviour
{
    // Delegates
    public delegate void OnSetSlot(Inventory inventory);
    public static event OnSetSlot OnSetSlotEvent;
    public delegate void OnRemoveSlot();
    public static event OnRemoveSlot OnRemoveSlotEvent;
    public delegate void OnCreateWindow(TextIcon icon);
    public static event OnCreateWindow OnCreateWindowEvent;
    
    // Instance of the inventory Scriptable Object
    [SerializeField] protected Inventory inventory;

    // public: gets used in drag manager

    void OnEnable()
    {
        // it requires the inventory scriptable object
        // DragManager.OnDropEvent += OnDrop;
        DragManager.OnDoubleClickEvent += DoubleClickEvent;
    }
    
    protected virtual void Start()
    {
        PopulateInitial();
    }
    /// <summary>
    /// Populates the inventory with some icons.
    /// </summary>
    public void PopulateInitial()
    {
        OnSetSlotEvent?.Invoke(inventory);
    }
    
    /// <summary>
    /// Removes the icon from all the non-specified slots.
    /// </summary>
    public void Clear() 
    {
        OnRemoveSlotEvent?.Invoke();
    }

    /// <summary>
    /// Removes the icon from all slots then populates the inventory with the specified icons.
    /// </summary>
    public void Refresh() 
    {
        // TODO: This is a bit of a hack.
            // This should be some sort of "should assemble" 
            // flag that gets called etc etc
        Clear();
        PopulateInitial();
    }
    // void OnDrop(IconInventorySlot iconInventorySlot)
    // {
    // }

    public void DoubleClickEvent(TextIcon icon)
    {
        OnCreateWindowEvent?.Invoke(icon);
    }

    void OnApplicationQuit()
    {
        SeralizedJSON<Inventory>.SaveScriptableObject(inventory,name);
    }
}
