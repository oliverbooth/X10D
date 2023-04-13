using System;
using UnityEngine;
using X10D.Drawing;
using X10D.Unity.Drawing;
using Color = UnityEngine.Color;

namespace X10D.Unity.Tests
{
    internal sealed class DebugUtilityIntegrationTests : MonoBehaviour
    {
        private void Update()
        {
            DebugUtility.DrawLine(Vector3.zero, Vector3.right, Color.red);
            DebugUtility.DrawLine(Vector3.zero, Vector3.up, Color.green);
            DebugUtility.DrawLine(Vector3.zero, Vector3.forward, Color.blue);

            DebugUtility.DrawWireCube(new Vector3(1.5f, 0.5f, 0), Vector3.one * 0.5f, Color.yellow);
            DebugUtility.DrawRectangle(new Vector2(-1.5f, 0.5f), Vector2.one * -0.5f, Color.cyan);

            var circle = new CircleF(0.0f, 0.0f, 0.5f);
            DebugUtility.DrawCircle(circle, 25, new Vector2(-3.0f, 0.5f), Color.magenta);

            var ellipse = new EllipseF(0.0f, 0.0f, 1.0f, 0.5f);
            DebugUtility.DrawEllipse(ellipse, 25, new Vector2(0.0f, 1.5f), Color.white);

            var hexagon = new PolygonF();
            hexagon.AddVertex(new Vector2(-0.5f, 0.5f));
            hexagon.AddVertex(new Vector2(-0.25f, 1.0f));
            hexagon.AddVertex(new Vector2(0.25f, 1.0f));
            hexagon.AddVertex(new Vector2(0.5f, 0.5f));
            hexagon.AddVertex(new Vector2(0.25f, 0));
            hexagon.AddVertex(new Vector2(-0.25f, 0));
            DebugUtility.DrawPolygon(hexagon, new Vector2(3.0f, 0.0f), Color.white);

            var sphere = new Sphere(System.Numerics.Vector3.Zero, 0.5f);
            DebugUtility.DrawSphere(sphere, 25, new Vector2(0.0f, -1.5f), Color.white);

            DebugUtility.DrawFunction(x => MathF.Sin(x + UnityEngine.Time.time % (2 * MathF.PI)), -10, 10, 0.1f, Vector3.up * 4,
                Color.yellow, 0.0f, false);

            DebugUtility.Assert(true);
        }
    }
}
