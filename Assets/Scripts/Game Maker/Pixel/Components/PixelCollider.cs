using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame
{
    public class PixelCollider : PixelComponent
    {
        public override void Create(Transform parent)
        {
            Instantiate<PixelScreen>(Resources.Load<PixelScreen>("Prefabs/Game/PixelScreen"), gameObject.transform);
        }
    }
}