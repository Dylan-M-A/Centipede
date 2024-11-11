using MathLibrary;
using Raylib_cs;

namespace Centipede
{
    internal class TestScene : Scene
    {
        Actor _theBoi;
        Actor _theBall;
        public override void Start()
        {
            base.Start();

            //add our cool actor
            Actor actor = new TestActor();
            actor.Transform.LocalPosition = new Vector2(100, 300);
            AddActor(actor);
            actor.Collider = new CirlceCollider(actor, 25);

            _theBoi = Actor.Instantiate(new Actor("The Boi"), null, new Vector2(125, 125), 0);
            _theBoi.Collider = new CirlceCollider(_theBoi, 25);

            //add the ball
            _theBall = Actor.Instantiate(new Actor("The Ball"), null, new Vector2(400, 200), 0);
            _theBall.Collider = new CirlceCollider(_theBall, 25);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Raylib.DrawRectangle(100, 100, 50, 50, Color.Green);

            Raylib.DrawCircle(400, 200, 25, Color.Red);
        }
    }
}
