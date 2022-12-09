using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame
{
    [MoonSharp.Interpreter.MoonSharpUserData]
    public class PixelTransform : PixelComponent
    {
        PixelGameObject self;
        PixelPosition position;
        AnchorPixel anchor;

        public override void Create(Transform parent)
        {
            position = new PixelPosition(0,0);
        }

        public PixelTransform add(AnchorPixel ap, PixelPosition pp /*hehe*/)
        {
            position = pp;
            anchor = ap;
            return this;
        }

        public PixelPosition move(PixelPosition pixelPosition)
        {
            gameObject.transform.localPosition += new Vector3(pixelPosition.x*100,pixelPosition.y*100,0);
            position = new PixelPosition((uint)(gameObject.transform.localPosition.x / 100f),(uint)(gameObject.transform.localPosition.y / 100f));
            return position;
        }

        public PixelPosition move(int x, int y)
        {
            gameObject.transform.localPosition += new Vector3(x*100,y*100,0);
            position = new PixelPosition((uint)(gameObject.transform.localPosition.x / 100f),(uint)(gameObject.transform.localPosition.y / 100f));
            return position;
        }
    }
}