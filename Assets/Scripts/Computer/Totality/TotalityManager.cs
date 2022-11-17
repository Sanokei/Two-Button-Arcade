using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BuildingBlocks.DataTypes;

[RequireComponent(typeof(RightClickMenuManager))]
public abstract class TotalityManager : MonoBehaviour
{
    public RightClickMenuManager RightClickMenuManager;
    public abstract InspectableDictionary<string,UnityEvent> Buttons{get;set;}
    void Awake()
    {
        RightClickMenuManager = gameObject.GetComponent<RightClickMenuManager>();
    }
}
