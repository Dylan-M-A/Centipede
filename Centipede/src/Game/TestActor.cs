using MathLibrary;
using Raylib_cs;

namespace Centipede
{
    internal class TestActor : Actor
    {
        public float Speed { get; set; } = 100;
        private Color _color;
        private Vector2 _rectangleSize = new Vector2();
        private KeyboardKey _up;
        private KeyboardKey _down;

        //creates the test actor for the scene
        public TestActor(KeyboardKey up, KeyboardKey down, Color color, string name = "TestActor") : base (name)
        {
            _rectangleSize = Transform.GlobalScale / 2 * 100;
            _up = up;
            _down = down;
            _color = color;
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            {
                //Movement
                Vector2 player1 = new Vector2();
                player1.y -= Raylib.IsKeyDown(_up);
                player1.y += Raylib.IsKeyDown(_down);
                Vector2 deltaMovement = player1.Normalized * Speed * (float)deltaTime;

                if (deltaMovement.Magnitude != 0)
                    Transform.LocalPosition += (deltaMovement);

                if ((ballPosition.x >= (_rectangleSize.x - ballRadius)) || (ballPosition.x <= ballRadius)) ballSpeed.x *= -1.0f;
                if ((ballPosition.y >= (_rectangleSize.y - ballRadius)) || (ballPosition.y <= ballRadius)) ballSpeed.y *= -1.0f;

                //helps offset the sqruare so the collision is inside the square
                Vector2 offset = _rectangleSize / 2;

                //draws the square
                Raylib.DrawRectangleV(Transform.GlobalPosition - offset, (_rectangleSize), _color);
            }

            {
                Vector2 player2 = new Vector2();
                player2.y -= Raylib.IsKeyDown(_up);
                player2.y += Raylib.IsKeyDown(_down);
                Vector2 deltaMovement = player2.Normalized * Speed * (float)deltaTime;

                if (deltaMovement.Magnitude != 0)
                    Transform.LocalPosition += (deltaMovement);

                if ((ballPosition.x >= (_rectangleSize.x - ballRadius)) || (ballPosition.x <= ballRadius)) ballSpeed.x *= -1.0f;
                if ((ballPosition.y >= (_rectangleSize.y - ballRadius)) || (ballPosition.y <= ballRadius)) ballSpeed.y *= -1.0f;

                Vector2 offset = _rectangleSize / 2;

                Raylib.DrawRectangleV(Transform.GlobalPosition - offset, (_rectangleSize), _color);
            }
        }
    }
}
