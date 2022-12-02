using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace PixelGame
{
    public class PixelSprite : PixelComponent
    {
        // Psuedo Sprite
        PixelScreen sprite; // Only use this to show on screen
        string SpriteString = "";

        public void add(string SpriteString)
        {
            this.SpriteString = SpriteString;
        }

        public override void Create(Transform parent)
        {
            sprite = Instantiate<PixelScreen>(Resources.Load<PixelScreen>("Prefabs/Game/PixelScreen"),parent);
            if(SpriteString != "")
            {
                sprite.ConvertSpriteStringToScreen(SpriteString);
            }
        }
    }
}