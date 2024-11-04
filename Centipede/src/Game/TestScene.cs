using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace Centipede
{
    internal class TestScene : Scene
    {
        Actor _theBoi;
        public override void Start()
        {
            base.Start();

            //add our cool actor
            Actor actor = new TestActor();
            actor.Transform.LocalPosition = new Vector2(200, 200);
            AddActor(actor);
            actor.Collider = new CirlceCollider(actor, 12);

            _theBoi = Actor.Instantaite(new Actor("The Boi"), null, new Vector2(100, 100), 0);
            _theBoi.Collider = new CirlceCollider(_theBoi, 37);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Raylib.DrawRectangleV(_theBoi.Transform.GlobalPosition, _theBoi.Transform.GlobalPosition /2, Color.Green);
        }
    }
}
