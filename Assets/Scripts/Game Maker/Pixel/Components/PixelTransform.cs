using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame
{
    public class PixelTransform : PixelComponent
    {
        PixelPosition position;
        AnchorPixel anchor;

        public override void Create(Transform parent)
        {
            position = new PixelPosition(0,0);
        }

        public void add(AnchorPixel ap, PixelPosition pp /*hehe*/)
        {
            position = pp;
            anchor = ap;
        }
    }
}