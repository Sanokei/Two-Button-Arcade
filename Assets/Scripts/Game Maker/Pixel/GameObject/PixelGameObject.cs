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
        public InspectableDictionary<string,PixelComponent> PixelComponents{get; protected set;}

        void OnEnable()
        {
            PixelComponents = new InspectableDictionary<string, PixelComponent>(); 
        }
        public dynamic this[string key] {
            get 
            {
                return PixelComponents[key];
            }
            set
            {
                PixelComponents.Add(key,value);
            }
        }
        public dynamic add(string key, dynamic value)
        {
            dynamic newValue = gameObject.AddComponent(value);
            if(newValue)
            {
                // FIXME: Bad place to put this
                if(newValue is PixelBehaviourScript) // if its a script
                    newValue.addPixelGameObjectToScriptGlobals(gameObject.name,this); // Add the game object to the scripts globals
                PixelComponents.Add(key,newValue);
                return newValue;
            }
            throw new MoonSharp.Interpreter.ScriptRuntimeException("Could Not Add Dynamic Value");
        }
    }
}