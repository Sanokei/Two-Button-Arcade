using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuildingBlocks.DataTypes;
using MoonSharp.Interpreter;

namespace PixelGame
{
    [MoonSharpUserData]
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
            // FIXME: Bad place to put this
            if(newValue is PixelBehaviourScript) // if its a script
                newValue.add(gameObject.name,this); // Add the game object to the scripts globals
            PixelComponents.Add(key,newValue);
            return newValue;
        }

        public InspectableDictionary<string,PixelComponent> PixelComponents{get;}

    }
}