using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede
{
    internal class SpriteComponent : Component
    {
        private Texture2D _texture;
        private string _path;

        public SpriteComponent(Actor owner, string path = "") : base(owner)
        {
            _path = path;
        }
    }
}
