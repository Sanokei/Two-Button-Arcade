using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;

using Lancet;
using System;
/*
script.Globals["test"] = new Action<string, MyEnum>(this.TestMethod);
```lua
test('hello world', MyEnum.Value1)
```
*/
namespace PixelGame
{
    public class PixelBehaviourScript : PixelComponent
    {
        string FileData;
        Script script = new Script();
        ScriptFunctionDelegate onOneButtonPress, onTwoButtonPress;
        ScriptFunctionDelegate onUpdate, onStart;
        
        void OnEnable()
        {
            Game.buttonOnePressEvent += ButtonOnePress;
            Game.buttonTwoPressEvent += ButtonTwoPress;
            Game.onUpdateEvent += OnUpdateEventHandler;
        }

        void OnDisable()
        {
            Game.buttonOnePressEvent -= ButtonOnePress;
            Game.buttonTwoPressEvent -= ButtonTwoPress;
            Game.onUpdateEvent -= OnUpdateEventHandler;
        }

        public void add(string FileData)
        {
            this.FileData = FileData;
        }
        public void add(string key, PixelGameObject value)
        {
            UserData.RegisterAssembly();
            script.Globals[key] = value;
        }
        public override void Create(Transform parent)
        {
            // add all the gameobjects to global variables for lua
            RunScript(FileData,script);
        }

        public void RunScript(string FileData, Script script)
        {
            // sets default options
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
            }catch{}
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