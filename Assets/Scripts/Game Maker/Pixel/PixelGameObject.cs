using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame
{
    public class PixelGameObject : MonoBehaviour
    {
        public PixelGameObject()
        {
            PixelComponents = new List<PixelComponent>();
        }
        public PixelGameObject(PixelComponent pixelComponent)
        {
            PixelComponents = new List<PixelComponent>();
            PixelComponents.Add(pixelComponent);
        }
        public void add(PixelComponent pixelComponent)
        {
            PixelComponents.Add(pixelComponent);
        }
        public List<PixelComponent> PixelComponents;
    }
}