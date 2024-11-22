using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Centipede
{
    internal class CirlceCollider : Collider
    {
        public float CollisionRadius { get; set; }

        public CirlceCollider(Actor owner, float radius) : base(owner)
        {
            CollisionRadius = radius;
        }

        //checks if there is a collision circle
        public override bool CheckCollisionCircle(CirlceCollider collider)
        {
            float sumRadii = collider.CollisionRadius + CollisionRadius;
            float distance = Vector2.Distance(collider.Owner.Transform.GlobalPosition, Owner.Transform.GlobalPosition);

            return sumRadii >= distance;
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
