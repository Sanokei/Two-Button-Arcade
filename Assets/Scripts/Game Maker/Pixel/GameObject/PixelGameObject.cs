using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuildingBlocks.DataTypes;

namespace PixelGame
{
    [MoonSharp.Interpreter.MoonSharpUserData]
    public class PixelGameObject : MonoBehaviour
    {
        public PixelComponent this[string key] {
        get 
        {
            return PixelComponents[key];
        }
        set
        {
           PixelComponents.Add(key,value);
        }
    }
        public PixelGameObject()
        {
            PixelComponents = new InspectableDictionary<string,PixelComponent>();
        }
        public dynamic add(string key, dynamic value)
        {
            dynamic newValue = gameObject.AddComponent(value);
            if(newValue is PixelBehaviourScript)
                newValue.add(gameObject.name,this);
            PixelComponents.Add(key,newValue);
            return newValue;
        }

        public InspectableDictionary<string,PixelComponent> PixelComponents{get;}
    }
}