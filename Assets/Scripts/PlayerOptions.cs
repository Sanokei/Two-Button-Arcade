using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

[System.Serializable]
public class PlayerOptions : MonoBehaviour
{
    //singleton
    public static PlayerOptions Instance{get; private set;}
    
    //
    public FileManager.editorThemeNames defaultTheme = FileManager.editorThemeNames.dark;
    public bool defaultShowReticle = true;
    public Camera Camera;
    public Canvas ScreenCanvas;
    public RectTransform ScreenCanvasRectTransform;

    // Create an instance of Options from a json in Awake then make this start
    void Awake() 
    {
        if(Instance != this)
            Destroy(this);
        Instance = Instance ?? this;
    }

    void OnEnable()
    {
        // Create all internal lua modules 
    }
}
