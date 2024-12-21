using MathLibrary;
using Raylib_cs;

namespace Centipede
{
    internal class TestActor : Actor
    {
        public float _speed { get; set; } = 100;
        public float _rotationSpeed { get; set; } = 3;
        public float _sizeSpeed { get; set; } = 1;
        private Color _color;
        private Vector2 _rectangleSize = new Vector2();
        private KeyboardKey _up;
        private KeyboardKey _down;
        private KeyboardKey _rotateRight;
        private KeyboardKey _rotateLeft;
        private KeyboardKey _sizeUp;

        //creates the test actor for the scene
        public TestActor(KeyboardKey up, KeyboardKey down, KeyboardKey rotateRight, KeyboardKey rotateLeft, KeyboardKey sizeUp, Color color, string name = "TestActor") : base (name)
        {
            _rectangleSize = Transform.GlobalScale / 2 * 100;
            _up = up;
            _down = down;
            _color = color;
            _rotateRight = rotateRight;
            _rotateLeft = rotateLeft;
            _sizeUp = sizeUp;
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            //Movement
            Vector2 player1 = new Vector2();
            player1.y -= Raylib.IsKeyDown(_up);
            player1.y += Raylib.IsKeyDown(_down);

            //gives player rotation
            if (Raylib.IsKeyDown(_rotateRight))
            {
                Transform.Rotate((float) -(Raylib.IsKeyDown(_rotateRight) * _rotationSpeed * deltaTime));
            }
            //opposite rotation
            if (Raylib.IsKeyDown(_rotateLeft))
            {
                Transform.Rotate((float) +(Raylib.IsKeyDown(_rotateLeft) * _rotationSpeed * deltaTime));
            }
            //increases player scale
            if (Raylib.IsKeyDown(_sizeUp))
            {
                Transform.Scale((float) +(Raylib.IsKeyDown(_sizeUp) * _sizeSpeed * deltaTime) + 1);
            }

            Vector2 deltaMovement = player1.Normalized * _speed * (float)deltaTime;

            if (deltaMovement.Magnitude != 0)
                Transform.LocalPosition += (deltaMovement);

            //helps offset the square so the collision is inside the square
            Vector2 offset = _rectangleSize / 2;

            //draws the player
            Rectangle rect = new Rectangle(Transform.GlobalPosition, _rectangleSize);
            Raylib.DrawRectanglePro(rect, new Vector2(0, 0) + offset, Transform.GlobalRotationAngle * (180 / (float)Math.PI), _color);
        }
        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);
        }
    }
}
