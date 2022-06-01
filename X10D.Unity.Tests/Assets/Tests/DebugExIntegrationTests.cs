using System.Drawing;
using UnityEngine;
using X10D.Drawing;
using X10D.Unity.Drawing;
using X10D.Unity.Numerics;
using Color = UnityEngine.Color;

namespace X10D.Unity.Tests
{
    internal sealed class DebugExIntegrationTests : MonoBehaviour
    {
        private void Update()
        {
            DebugEx.DrawLine(Vector3.zero, Vector3.right, Color.red);
            DebugEx.DrawLine(Vector3.zero, Vector3.up, Color.green);
            DebugEx.DrawLine(Vector3.zero, Vector3.forward, Color.blue);

            DebugEx.DrawBox(new Vector3(1.5f, 0.5f, 0), Vector3.one * 0.5f, Color.yellow);
            DebugEx.DrawRectangle(new Vector2(-1.5f, 0.5f), Vector2.one * -0.5f, Color.cyan);

            var circle = new CircleF(0.0f, 0.0f, 0.5f);
            DebugEx.DrawCircle(circle, 25, new Vector2(-3.0f, 0.5f), Color.magenta);

            var ellipse = new EllipseF(0.0f, 0.0f, 1.0f, 0.5f);
            DebugEx.DrawEllipse(ellipse, 25, new Vector2(0.0f, 1.5f), Color.white);

            var hexagon = new PolygonF();
            hexagon.AddPoint(new Vector2(-0.5f, 0.5f));
            hexagon.AddPoint(new Vector2(-0.25f, 1.0f));
            hexagon.AddPoint(new Vector2(0.25f, 1.0f));
            hexagon.AddPoint(new Vector2(0.5f, 0.5f));
            hexagon.AddPoint(new Vector2(0.25f, 0));
            hexagon.AddPoint(new Vector2(-0.25f, 0));
            DebugEx.DrawPolygon(hexagon, new Vector2(3.0f, 0.0f), Color.white);

            var sphere = new Sphere(System.Numerics.Vector3.Zero, 0.5f);
            DebugEx.DrawSphere(sphere, 25, new Vector2(0.0f, -1.5f), Color.white);
            
            DebugEx.Assert(true);
        }
    }
}
