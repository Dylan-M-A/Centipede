using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace Centipede
{
    internal class RectangleComponent : Component
    {
        private Color _color = Color.Green;
        private float _sizeScale = 50;

        public RectangleComponent(Actor owner, Color color) : base(owner)
        {
            _color = color;
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            if (Owner != null)
            {
                Vector2 offset = Owner.Transform.GlobalScale * _sizeScale / 2;
                Rectangle rect = new Rectangle(Owner.Transform.GlobalPosition, Owner.Transform.GlobalScale * _sizeScale);
                Raylib.DrawRectanglePro(rect, new Vector2(0, 0) + offset, Owner.Transform.GlobalRotationAngle * (180 / (float)Math.PI), _color);
            }
        }
    }
}
