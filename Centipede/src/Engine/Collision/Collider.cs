using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede
{
    internal class Collider
    {
        Actor _theBall;

        public Actor Owner { get; protected set; }

        public Collider(Actor owner)
        {
            Owner = owner;
        }

        public bool CheckCollision(Actor other)
        {
            if (other.Collider != null && other.Collider is CirlceCollider)
                return CheckCollisionCircle((CirlceCollider)other.Collider);
            return false;
        }

        public virtual bool CheckCollisionCircle(CirlceCollider collider)
        {
            return false;
        }

        public virtual void Draw() { }

        public void Bounce()
        {
            if (_theBall.OnCollision == TestActor.ReferenceEquals)
            {

            }
        }
    }
}
