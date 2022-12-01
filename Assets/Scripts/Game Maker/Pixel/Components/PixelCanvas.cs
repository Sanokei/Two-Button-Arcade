using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame
{
    public class PixelCanvas : PixelComponent
    {
        PixelSprite canvas = new PixelSprite("oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
        public override void Create(Transform parent)
        {
            canvas.Create(parent);
        }
    }
}