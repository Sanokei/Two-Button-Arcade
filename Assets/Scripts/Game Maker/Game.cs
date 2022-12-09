using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BuildingBlocks.DataTypes;
using System.Text;

using MoonSharp.Interpreter;

using PixelGame;
[MoonSharpUserData]
public abstract class Game : MonoBehaviour, IPixelObject
{
    public delegate void OnButtonClickDelegate();
    public static OnButtonClickDelegate buttonOnePressEvent,buttonTwoPressEvent;
    public delegate void OnUpdateDelegate();
    public static OnUpdateDelegate onUpdateEvent;
    public abstract void StartGame();
    public ArcadeManager Cabinet;

    void OnEnable()
    {
        Eyes.OnRayCastHitEvent += ButtonPress;
    }

    void OnDisable()
    {
        Eyes.OnRayCastHitEvent -= ButtonPress;
    }

    void ButtonPress(RaycastHit hit)
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            buttonOnePressEvent?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            buttonTwoPressEvent?.Invoke();
        }
    }
    void Update()
    {
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
    /*****************************************************/
    public Image Skybox;
    public InspectableDictionary<string,PixelGameObject> PixelGameObjects = new InspectableDictionary<string, PixelGameObject>();

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
    public PixelGameObject add(string key)
    {        
        if(!PixelGameObjects.Keys.Contains(key))  
        {
            PixelGameObject value = Instantiate<PixelGameObject>(Resources.Load<PixelGameObject>("Prefabs/Game/PixelGameObject"), gameObject.transform);
            value.name = key;
            PixelGameObjects.Add(key, value);
            return value;
        }
        throw new ScriptRuntimeException("Key already used to make PixelGameObject");
    }

    // public void CompileAndRun()
    // {
    //     // <string,Layer>
    //     foreach(PixelGameObject key in PixelGameObjects.Values)
    //     {
    //         // spawn the components
    //         foreach(PixelComponent pixelComponent in key.PixelComponents.Values)
    //         {
    //             pixelComponent.Create(key.gameObject.transform);
    //         }
    //     }
    // }
    public string SpriteStringMaker(DynValue SpriteString)
    {
        // https://github.com/moonsharp-devs/moonsharp/blob/master/src/MoonSharp.Interpreter/Interop/Converters/TableConversions.cs
        // The level of abstraction in their code makes me want to commit sepukku
        // layers and layers of fucking private internal
        return SpriteStringMaker((Dictionary<PixelPosition,char>) SpriteString.ToObject(typeof(Dictionary<PixelPosition,char>)));
    }
    public string SpriteStringMaker(Dictionary<PixelPosition,char> SpriteString)
    {
        StringBuilder Default = new StringBuilder("oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
        foreach(PixelPosition key in SpriteString.Keys)
        {
            Default[(int)((key.x * 8) + key.y)] = SpriteString[key];
        }
        return Default.ToString();
    }
}

