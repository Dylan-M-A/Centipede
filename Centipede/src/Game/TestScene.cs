using MathLibrary;
using Raylib_cs;

namespace Centipede
{
    internal class TestScene : Scene
    {
        public Actor _theBall;

        public override void Start()
        {
            base.Start();

            //add our cool actor
            Actor actor = new TestActor(KeyboardKey.W, KeyboardKey.S, Color.Blue, "player1");
            actor.Transform.LocalPosition = new Vector2(50, 300);
            AddActor(actor);
            actor.Collider = new CirlceCollider(actor, 25);

            Actor actor2 = new TestActor(KeyboardKey.Up, KeyboardKey.Down, Color.Green, "player2");
            actor2.Transform.LocalPosition = new Vector2(750, 300);
            AddActor(actor2);
            actor2.Collider = new CirlceCollider(actor2, 25);

            //add the ball
            _theBall = Actor.Instantiate(new Actor("The Ball"), null, new Vector2(400, 240), 0);
            _theBall.Collider = new CirlceCollider(_theBall, 10);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Raylib.DrawCircle(400, 240, 10, Color.Red);

            //ball movement
        }
    }
}
