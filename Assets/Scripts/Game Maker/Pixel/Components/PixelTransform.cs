using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame
{
    public class PixelTransform : PixelComponent
    {
        PixelPosition position;
        AnchorPixel anchor;
        public PixelTransform(int PosX, int PosY, int AnchorX, int AnchorY)
        {
            position = new PixelPosition((uint)PosX,(uint)PosY);
            anchor.position = new PixelPosition((uint)AnchorX,(uint)AnchorY);
        }

        public override void Create(Transform parent)
        {
            
        }
    }
}