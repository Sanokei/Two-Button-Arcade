using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[MoonSharp.Interpreter.MoonSharpUserData]
public class AlphaJargon : JargonEngine
{
    [HideInInspector] public JargonCompiler Compiler;
    void Awake()
    {
        Compiler = gameObject.AddComponent<JargonCompiler>();

        // https://www.moonsharp.org/scriptloaders.html
        ((MoonSharp.Interpreter.Loaders.ScriptLoaderBase)
        MoonSharp.Interpreter.Script.DefaultOptions.ScriptLoader).ModulePaths = 
        new string[]
        {
            "MyPath/?",
            "MyPath/?.lua"
        };

        // only run this for "require"
        Compiler.Init(game);
    }
    public override void AwakeGame()
    {
        awakeGameEvent?.Invoke();
    }

    public override void InitializeGame()
    {
        initializeGameEvent?.Invoke();
    }

    public override void StartGame()
    {
        startGameEvent?.Invoke();
    }
}
