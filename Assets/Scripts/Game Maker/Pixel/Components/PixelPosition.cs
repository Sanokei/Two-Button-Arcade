using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame
{
    public class PixelPosition
    {
        public uint x;
        public uint y;

        public PixelPosition()
        {
            x = 0;
            y = 0;
        }

        public PixelPosition(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }
    }
}