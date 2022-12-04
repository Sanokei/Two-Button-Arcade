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
        string FileName;
        string FileData;
        Script script = new Script();
        PixelScript pixelScript;
        public void add(string FileName, string FileData)
        {
            this.FileName = FileName;
            this.FileData = FileData;
        }
        public override void Create(Transform parent)
        {
            StartCoroutine(InstantiatePixelScript(parent));
            // add all the gameobjects to global variables for lua
            pixelScript.RunScript(FileData,script);
        }

        IEnumerator InstantiatePixelScript(Transform parent)
        {
            pixelScript = Instantiate<PixelScript>(Resources.Load<PixelScript>("Prefabs/Game/PixelScript"),parent);
            yield return null;
        }
    }
}