using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace Centipede
{
    internal class Ball : Actor
    {
        Actor _theBall;

        public float Speed { get; set; } = 100;
        private Color _color = Color.Red;

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Raylib.DrawCircleV(_theBall.Transform.GlobalPosition, 25, _color);
        }
    }
}
