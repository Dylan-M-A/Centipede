using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace Centipede
{
    internal class TestScene : Scene
    {
        public override void Start()
        {
            base.Start();

            //add our cool actor
            Actor actor = new TestActor();
            actor.Transform.LocalPosition = new Vector2(200, 200);
            AddActor(actor);
        }
    }
}
