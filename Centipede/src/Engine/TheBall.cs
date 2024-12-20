using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede
{
    internal class TheBall : Actor
    {
        public float Radius;
        public TheBall() : base("ball")
        {
            Position = ballPosition;
            Radius = ballRadius;
            Speed = ballSpeed.x;
            Speed = ballSpeed.y;
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            ballPosition.x += ballSpeed.x;
            ballPosition.y += ballSpeed.y;

            if ((ballPosition.x >= (WIN_WIDTH - ballRadius)) || (ballPosition.x <= ballRadius)) ballSpeed.x *= -1.0f;
            if ((ballPosition.y >= (WIN_HEIGHT - ballRadius)) || (ballPosition.y <= ballRadius)) ballSpeed.y *= -1.0f;
        }
    }
}
