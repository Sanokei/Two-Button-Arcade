using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace PixelGame
{
    [MoonSharp.Interpreter.MoonSharpUserData]
    public class PixelSprite : PixelComponent
    {
        // Psuedo Sprite
        PixelScreen sprite; // Only use this to show on screen
        public string SpriteString = "";
        public void add(string SpriteString)
        {
            this.SpriteString = SpriteString;
            if(SpriteString != "")
            {
                sprite.ConvertSpriteStringToScreen(SpriteString);
            }
        }

        public override void Create(PixelGameObject parent)
        {
            // FIXME: add to PixelGameObject instead as "Child"
            sprite = Instantiate<PixelScreen>(Resources.Load<PixelScreen>("Prefabs/Game/PixelScreen"),parent.gameObject.transform);
            if(SpriteString != "")
            {
                sprite.ConvertSpriteStringToScreen(SpriteString);
            }
        }
    }
}