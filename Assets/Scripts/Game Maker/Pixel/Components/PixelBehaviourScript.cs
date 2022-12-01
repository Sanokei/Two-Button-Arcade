using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;

using Lancet;
using System;

namespace PixelGame
{
    public class PixelBehaviourScript : PixelComponent
    {
        ScriptFunctionDelegate onOneButtonPress, onTwoButtonPress;
        ScriptFunctionDelegate onUpdate, onStart;

        string FileData;
        Script script = new Script();
        public PixelBehaviourScript(string FileData)
        {
            this.FileData = FileData;
        }
        public override void Create(Transform parent)
        {
            Game.buttonOnePressEvent += ButtonOnePress;
            Game.buttonTwoPressEvent += ButtonTwoPress;
            Game.onUpdateEvent += OnUpdateEventHandler;

            script.Options.DebugPrint = (x) => {Debug.Log(x);};
            ((ScriptLoaderBase)script.Options.ScriptLoader).IgnoreLuaPathGlobal = true;
            ((ScriptLoaderBase)script.Options.ScriptLoader).ModulePaths = ScriptLoaderBase.UnpackStringPaths(System.IO.Path.Combine(Application.persistentDataPath,"?") + ".lua");
            // adds a lot of the internal commands
            // script.Globals["internal"] = new Internal();

            DynValue fn = script.LoadString(FileData);
            fn.Function.Call();
            try
            {
                onStart = script.Globals.Get("Start").Function.GetDelegate();
                onOneButtonPress = script.Globals.Get("ButtonOnePress").Function.GetDelegate();
                onTwoButtonPress = script.Globals.Get("ButtonTwoPress").Function.GetDelegate();
            }
            catch
            {

            }
            
            // 
            // onAwake
            onStart?.Invoke();

            try
            {
                onUpdate = script.Globals.Get("Update").Function.GetDelegate();
            }
            catch
            {

            }
            
        }

        private void OnUpdateEventHandler()
        {
            onUpdate?.Invoke();
        }

        public void ButtonOnePress()
        {
            onOneButtonPress?.Invoke();
        }

        public void ButtonTwoPress()
        {
            onTwoButtonPress?.Invoke();
        }
    }
}