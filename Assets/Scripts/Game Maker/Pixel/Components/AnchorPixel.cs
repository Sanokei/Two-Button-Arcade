using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame
{
    public class AnchorPixel : PixelComponent
    {
        public PixelPosition position;
        public PixelSprite sprite;

        public override void Create(Transform parent)
        {
            position = new PixelPosition(0,0);
        }

        public void add(PixelSprite ps, PixelPosition pp)
        {
            sprite = ps;
            position = pp;
        }
    }
}