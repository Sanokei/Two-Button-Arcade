using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using BuildingBlocks.DataTypes;

[System.Serializable]
public class Sanject : MonoBehaviour
{
    //singleton
    public static Sanject Instance{get; private set;}
    
    // This is like my bad attempt at dependency injection.
    // I will use ZenJect or something similar another time.
    // for now I will do it like this and suffer lol
    // kill me now

    // Prefabs
    public GameObject HierarchyElement;
    public GameObject RightClickMenu;
    public GameObject Option;

    //
    public FileManager.editorThemeNames defaultTheme = FileManager.editorThemeNames.dark;
    public bool defaultShowReticle = true;
    
    // DragUI
    public Camera Camera;
    public Canvas ScreenCanvas;
    public RectTransform ScreenCanvasRectTransform;

    // Hierarchy
    public Transform HierarchyTransform;

    // The current RightClickOption 'button' for the options menu in RightClickMenuManager
    public InspectableDictionary<string, UnityEvent> CurrentOptionButton;

    // Create an instance of Options from a json in Awake then make this start
    void Awake() 
    {
        if(Instance != this)
            Destroy(this);
        Instance = Instance ?? this;
    }
}
