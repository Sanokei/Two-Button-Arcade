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

        public override void Create(PixelGameObject parent)
        {
            position = new PixelPosition(0,0);
        }

        public PixelTransform add(PixelPosition pp /*hehe*/)
        {
            position = pp;
            move(pp);
            return this;
        }

        public PixelPosition move(PixelPosition pixelPosition)
        {
            return move(pixelPosition.x, pixelPosition.y);
        }

        public PixelPosition move(int x, int y)
        {
            // FIXME:
            // funky stuff happens when I try to make this 
            // gameobject.transform.Translate
            // no idea why
            gameObject.transform.localPosition += new Vector3(x*100,y*100,0);
            position = new PixelPosition((int)(gameObject.transform.localPosition.x / 100f),(int)(gameObject.transform.localPosition.y / 100f));
            return position;
        }
    }
}