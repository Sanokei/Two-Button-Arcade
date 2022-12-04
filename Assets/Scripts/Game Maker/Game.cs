using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using BuildingBlocks.DataTypes;
using System.Text;

using PixelGame;

public abstract class Game : MonoBehaviour
{
    public delegate void OnButtonClickDelegate();
    public static OnButtonClickDelegate buttonOnePressEvent,buttonTwoPressEvent;
    public delegate void OnUpdateDelegate();
    public static OnUpdateDelegate onUpdateEvent;
    public abstract void StartGame();
    public ArcadeManager Cabinet;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            buttonOnePressEvent?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            buttonTwoPressEvent?.Invoke();
        }
        onUpdateEvent?.Invoke();
    }

    public void setCabinet(ArcadeManager cabinet)
    {
        this.Cabinet = cabinet;
    }
    
    public Game game
    {
        get
        {
            return this;
        }
    }
    public Image Skybox;

    public InspectableDictionary<string,PixelGameObject> PixelGameObjects;

    public PixelGameObject this[string key] {
        get 
        {
            return PixelGameObjects[key];
        }
        set
        {
            PixelGameObjects[key] = value;
        }
    }

    // add components to gameobjects
    public void add(string key, PixelGameObject value)
    {
        PixelGameObjects.Add(key,value);
    }

    public void CompileAndRun(Transform ScreenParent)
    {
        // <string,Layer>
        foreach(string key in PixelGameObjects.Keys)
        {
            // spawn the components
            foreach(PixelComponent pixelComponent in PixelGameObjects[key].PixelComponents.Values)
            {
                if(pixelComponent is PixelBehaviourScript)
                    pixelComponent.Create(Cabinet.Computer.transform);
                else
                    pixelComponent.Create(ScreenParent);
            }
        }
    }

    public string SpriteStringMaker(InspectableDictionary<PixelPosition,char> SpriteString)
        {
            StringBuilder Default = new StringBuilder("oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
            foreach(PixelPosition key in SpriteString.Keys)
            {
                Default[(int)((key.x * 8) + key.y)] = SpriteString[key];
            }
            return Default.ToString();
        }
}

