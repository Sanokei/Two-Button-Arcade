using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Habrador_Computational_Geometry;
namespace PixelGame
{
    public class PixelCollider : PixelComponent
    {
        List<PolygonCollider2D> pixelCollider;
        public override void Create(PixelGameObject parent)
        {
            pixelCollider = new List<PolygonCollider2D>();
        }

        public PolygonCollider2D add(List<PixelPosition> pixelPositions)
        {
            // convert all the pixel positions to coords
            List<MyVector2> Points = new List<MyVector2>();
            foreach (PixelPosition pixelPosition in pixelPositions)
            {
                Points.Add(new MyVector2(pixelPosition.x * 100 - 400, pixelPosition.y * 100 - 400));
                Points.Add(new MyVector2(pixelPosition.x * 100 - 400, (pixelPosition.y + 1) * 100 - 400));
                Points.Add(new MyVector2((pixelPosition.x + 1) * 100 - 400, (pixelPosition.y + 1) * 100 - 400));
                Points.Add(new MyVector2((pixelPosition.x + 1) * 100 - 400, pixelPosition.y * 100 - 400));
            }
            
            // get the perimeter using 'quickhull' convex hull algorithm
            PolygonCollider2D pc2d = gameObject.AddComponent<PolygonCollider2D>();
            pc2d.SetPath(0, MyVector2ToVector2(QuickhullAlgorithm2D.GenerateConvexHull(Points, false)));
            pixelCollider.Add(pc2d);

            return pixelCollider[pixelCollider.Count - 1];
        }

        List<Vector2> MyVector2ToVector2(List<MyVector2> myVector2List)
        {
            List<Vector2> vector2List = new List<Vector2>();
            foreach (MyVector2 myVector2 in myVector2List)
            {
                vector2List.Add(new Vector2(myVector2.x, myVector2.y));
            }
            return vector2List;
        }
    }
}