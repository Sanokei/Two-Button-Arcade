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
    [MoonSharp.Interpreter.MoonSharpUserData]
    public class PixelBehaviourScript : PixelComponent
    {
        string FileData;
        Script script = new Script();
        ScriptFunctionDelegate onOneButtonPress, onTwoButtonPress, onOneButtonUp, onTwoButtonUp;
        ScriptFunctionDelegate onUpdate, onStart;

        // public ScriptFunctionDelegate's to use as the pixel components
        ScriptFunctionDelegate onTriggerEnter, onTriggerStay, onTriggerExit;
        ScriptFunctionDelegate onCollisionEnter, onCollisionStay, onCollisionExit;
        
        void OnEnable()
        {
            Game.buttonOnePressEvent += ButtonOnePress;
            Game.buttonTwoPressEvent += ButtonTwoPress;
            Game.buttonOneUpEvent += ButtonOneUp;
            Game.buttonTwoUpEvent += ButtonTwoUp;

            Game.onUpdateEvent += OnUpdateEventHandler;

            PixelCollider.onTriggerEnter += TriggerEnter;
            PixelCollider.onTriggerStay += TriggerStay;
            PixelCollider.onTriggerExit += TriggerExit;

            PixelCollider.onCollisionEnter += CollisionEnter;
            PixelCollider.onCollisionStay += CollisionStay;
            PixelCollider.onCollisionExit += CollisionExit;
        }

        void OnDisable()
        {
            Game.buttonOnePressEvent -= ButtonOnePress;
            Game.buttonTwoPressEvent -= ButtonTwoPress;
            Game.buttonOneUpEvent -= ButtonOneUp;
            Game.buttonTwoUpEvent -= ButtonTwoUp;
            
            Game.onUpdateEvent -= OnUpdateEventHandler;

            PixelCollider.onTriggerEnter += TriggerEnter;
            PixelCollider.onTriggerStay += TriggerStay;
            PixelCollider.onTriggerExit += TriggerExit;

            PixelCollider.onCollisionEnter += CollisionEnter;
            PixelCollider.onCollisionStay += CollisionStay;
            PixelCollider.onCollisionExit += CollisionExit;
        }

        public void add(string FileData)
        {
            this.FileData = FileData;
        }
        public void addPixelGameObjectToScriptGlobals(string key, IPixelObject value)
        {
            UserData.RegisterAssembly();
            script.Globals[key] = value;
        }
        public override void Create(PixelGameObject parent)
        {
            addPixelGameObjectToScriptGlobals("game",parent);
        }

        public void RunScript()
        {
            UserData.RegisterAssembly();

            // sets default options
            script.Options.DebugPrint = (x) => {Debug.Log(x);};
            ((ScriptLoaderBase)script.Options.ScriptLoader).IgnoreLuaPathGlobal = true;
            ((ScriptLoaderBase)script.Options.ScriptLoader).ModulePaths = ScriptLoaderBase.UnpackStringPaths(System.IO.Path.Combine(Application.persistentDataPath,"/modules/","?") + ".lua");
            
            // adds a lot of the internal commands
            // script.Globals["internal"] = new Internal();

            DynValue fn = script.LoadString(FileData);
            fn.Function.Call();

            // cant do null checks cuz .Get returns DynValue.Nil not null
            // onStart = script.Globals.Get("Start").Function.GetDelegate() ?? null;

            onStart = script.Globals.Get("Start") != DynValue.Nil ? script.Globals.Get("Start").Function.GetDelegate() : null;

            onOneButtonPress = script.Globals.Get("ButtonOnePress") != DynValue.Nil ? script.Globals.Get("ButtonOnePress").Function.GetDelegate() : null;
            onTwoButtonPress = script.Globals.Get("ButtonTwoPress") != DynValue.Nil ? script.Globals.Get("ButtonTwoPress").Function.GetDelegate() : null;
            onOneButtonUp = script.Globals.Get("ButtonOneUp") != DynValue.Nil ? script.Globals.Get("ButtonOneUp").Function.GetDelegate() : null;
            onTwoButtonUp = script.Globals.Get("ButtonTwoUp") != DynValue.Nil ? script.Globals.Get("ButtonTwoUp").Function.GetDelegate() : null;

            onCollisionEnter = script.Globals.Get("OnCollisionEnter") != DynValue.Nil ? script.Globals.Get("OnCollisionEnter").Function.GetDelegate() : null;
            onCollisionStay = script.Globals.Get("OnCollisionStay") != DynValue.Nil ? script.Globals.Get("OnCollisionStay").Function.GetDelegate() : null;
            onCollisionExit = script.Globals.Get("OnCollisionExit") != DynValue.Nil ? script.Globals.Get("OnCollisionExit").Function.GetDelegate() : null;


            onTriggerEnter = script.Globals.Get("OnTriggerEnter") != DynValue.Nil ? script.Globals.Get("OnTriggerEnter").Function.GetDelegate() : null;
            onTriggerStay = script.Globals.Get("OnTriggerStay") != DynValue.Nil ? script.Globals.Get("OnTriggerStay").Function.GetDelegate() : null;
            onTriggerExit = script.Globals.Get("OnTriggerExit") != DynValue.Nil ? script.Globals.Get("OnTriggerExit").Function.GetDelegate() : null;
            
            
            // onAwake
            onStart?.Invoke();
            onUpdate = script.Globals.Get("Update") != DynValue.Nil ? script.Globals.Get("Update").Function.GetDelegate() : null;
        }

        // all event handlers that invoke script delegate
        private void OnUpdateEventHandler()
        {
            onUpdate?.Invoke();
        }

        private void ButtonOnePress()
        {
            onOneButtonPress?.Invoke();
        }

        private void ButtonTwoPress()
        {
            onTwoButtonPress?.Invoke();
        }
        private void ButtonTwoUp()
        {
            onTwoButtonUp?.Invoke();
        }

        private void ButtonOneUp()
        {
            onOneButtonUp?.Invoke();
        }

        //
        private void TriggerEnter(Collider2D other, PixelGameObject parent)
        {
            onTriggerEnter?.Invoke(DynValue.NewString(parent.name));
        }
        private void TriggerStay(Collider2D other, PixelGameObject parent)
        {
            onTriggerStay?.Invoke(DynValue.NewString(parent.name));
        }
        private void TriggerExit(Collider2D other, PixelGameObject parent)
        {
            onTriggerExit?.Invoke(DynValue.NewString(parent.name));
        }
        //
        private void CollisionEnter(Collision2D other, PixelGameObject parent)
        {
            onCollisionEnter?.Invoke(DynValue.NewString(parent.name));
        } 
        private void CollisionStay(Collision2D other, PixelGameObject parent)
        {
            onCollisionStay?.Invoke(DynValue.NewString(parent.name));
        }
        private void CollisionExit(Collision2D other, PixelGameObject parent)
        {
            onCollisionExit?.Invoke(DynValue.NewString(parent.name));
        }
    }
}