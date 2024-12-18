using MathLibrary;
using Raylib_cs;

namespace Centipede
{
    internal class TestActor : Actor
    {
        public float _speed { get; set; } = 100;
        public float _rotationSpeed { get; set; } = 3;
        public float _sizeSpeed { get; set; } = 5;
        private Color _color;
        private Vector2 _rectangleSize = new Vector2();
        private KeyboardKey _up;
        private KeyboardKey _down;

        public override void Rotate(float radians)
        {
            base.Rotate(radians);
        }

        public override void Scale(float scalar)
        {
            base.Scale(scalar);
        }

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

                if (Raylib.IsKeyDown(KeyboardKey.E))
                {
                    Console.WriteLine(Transform.GlobalRotationAngle);
                    Transform.Rotate((float) -(Raylib.IsKeyDown(KeyboardKey.E) * _rotationSpeed * deltaTime));
                }                

                if (Raylib.IsKeyDown(KeyboardKey.I))
                {
                    Console.WriteLine(Transform.GlobalRotationAngle);
                    Transform.Scale((float) -(Raylib.IsKeyDown(KeyboardKey.I) * _sizeSpeed * deltaTime));
                }

                Vector2 deltaMovement = player1.Normalized * _speed * (float)deltaTime;

                if (deltaMovement.Magnitude != 0)
                    Transform.LocalPosition += (deltaMovement);

                //helps offset the sqruare so the collision is inside the square
                Vector2 offset = _rectangleSize / 2;

                //draws the square
                Rectangle rect = new Rectangle(Transform.GlobalPosition, _rectangleSize);
                Raylib.DrawRectanglePro(rect, new Vector2(0, 0) + offset, Transform.GlobalRotationAngle * (180 / (float)Math.PI), _color);
            }

            Vector2 child = new Vector2();

            Vector2 deltaMovement1 = child.Normalized * _speed * (float)deltaTime;

            if (deltaMovement1.Magnitude != 0)
                Transform.LocalPosition += (deltaMovement1);

            //helps offset the sqruare so the collision is inside the square
            Vector2 offset1 = _rectangleSize / 2;

            //draws the square
            Raylib.DrawRectangle(50, 250, 25, 25, _color);

            {
                Vector2 player2 = new Vector2();
                player2.y -= Raylib.IsKeyDown(_up);
                player2.y += Raylib.IsKeyDown(_down);
                if (Raylib.IsKeyDown(KeyboardKey.K))
                {
                    Transform.Rotate((float)-(Raylib.IsKeyDown(KeyboardKey.K) * _rotationSpeed * deltaTime));
                }
                Vector2 deltaMovement = player2.Normalized * _speed * (float)deltaTime;

                if (deltaMovement.Magnitude != 0)
                    Transform.LocalPosition += (deltaMovement);

                Vector2 offset = _rectangleSize / 2;

                Rectangle rect = new Rectangle(Transform.GlobalPosition, _rectangleSize);
                Raylib.DrawRectanglePro(rect, new Vector2(0, 0) + offset, Transform.GlobalRotationAngle * (180 / (float)Math.PI), _color);
            }
        }
        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);

            if ((ballPosition.x >= (_rectangleSize.x - ballRadius)) || (ballPosition.x <= ballRadius)) 
                ballSpeed.x *= -1.0f;

            if ((ballPosition.y >= (_rectangleSize.y - ballRadius)) || (ballPosition.y <= ballRadius)) 
                ballSpeed.y *= -1.0f;
        }
    }
}
