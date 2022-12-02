using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuildingBlocks.DataTypes;

namespace PixelGame
{
    public class PixelGameObject : MonoBehaviour
    {
        public PixelGameObject()
        {
            PixelComponents = new InspectableDictionary<string,PixelComponent>();
        }
        public void add(string key, PixelComponent pixelComponent)
        {
            PixelComponents.Add(key, pixelComponent);
        }
        public InspectableDictionary<string,PixelComponent> PixelComponents{get;}
    }
}