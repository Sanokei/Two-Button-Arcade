using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using BuildingBlocks.DataTypes;

public class HierarchyManager : TotalityManager
{

    public override InspectableDictionary<string, UnityEvent> Buttons { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    // // This is all pretty shit tbh
    // void Awake()
    // {
    //     // Really wishing I used dependency injection right about now
    //     // cuz then i could Instantiate needed RightClickOption as Scriptable Objects

    // }
    void Start()
    {
        RightClickMenuManager.Buttons = this.Buttons;
    }

    public void CreateHierarchyElement()
    {
        Instantiate(Sanject.Instance.HierarchyElement, Sanject.Instance.HierarchyTransform);
    }
}
