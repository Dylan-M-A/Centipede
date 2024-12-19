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

            Actor actor3 = Actor.Instantiate(new Actor("child"), actor.Transform, new Vector2(50, 250), 0);
            AddActor(actor3);
            actor3.Collider = new CirlceCollider(actor3, 25);

            //add the ball
            _theBall = Actor.Instantiate(new Actor("The Ball"), null, ballPosition, 0);
            _theBall.Collider = new CirlceCollider(_theBall, 10);
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Raylib.DrawCircleV(ballPosition, ballRadius, Color.Red);

            ballPosition.x += ballSpeed.x;
            ballPosition.y += ballSpeed.y;

            if ((ballPosition.x >= (WIN_WIDTH - ballRadius)) || (ballPosition.x <= ballRadius)) ballSpeed.x *= -1.0f;
            if ((ballPosition.y >= (WIN_HEIGHT - ballRadius)) || (ballPosition.y <= ballRadius)) ballSpeed.y *= -1.0f;
        }
    }
}
