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
        
        string FileData;
        Script script = new Script();
        PixelScript pixelScript;
        public void add(string FileData)
        {
            this.FileData = FileData;
        }
        public override void Create(Transform parent)
        {
            StartCoroutine(InstantiatePixelScript(parent));
            pixelScript.RunScript(FileData,script);
        }

        IEnumerator InstantiatePixelScript(Transform parent)
        {
            pixelScript = Instantiate<PixelScript>(Resources.Load<PixelScript>("Prefabs/Game/PixelScript"),parent);
            yield return null;
        }
    }
}