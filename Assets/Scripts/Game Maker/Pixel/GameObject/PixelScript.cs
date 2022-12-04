using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;

using TMPro;
using InGameCodeEditor;

using Lancet;
using System;

namespace PixelGame
{
    public class PixelScript : PixelGameObject
    {
        ScriptFunctionDelegate onOneButtonPress, onTwoButtonPress;
        ScriptFunctionDelegate onUpdate, onStart;

        public TextMeshProUGUI filename;

        void OnEnable()
        {
            Game.buttonOnePressEvent += ButtonOnePress;
            Game.buttonTwoPressEvent += ButtonTwoPress;
            Game.onUpdateEvent += OnUpdateEventHandler;
        }
        public void RunScript(TextIcon FileData, Script script)
        {
            RunScript(FileData.FileData, script);
        }
        public void RunScript(string FileData, Script script)
        {
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