using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame
{
    public class PixelCanvas : PixelComponent
    {
        PixelSprite canvas;

        public override void Create(Transform parent)
        {
            canvas = gameObject.AddComponent<PixelSprite>();
            canvas.add("oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
            canvas.Create(gameObject.transform);
        }
    }
}