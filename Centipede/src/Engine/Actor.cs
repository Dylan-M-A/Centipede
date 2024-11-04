using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Centipede
{
    internal class Actor
    {
        private bool _started = false;
        private bool _enabled = true;

        public bool Started { get => _started; }

        public bool Enabled
        {
            get => _enabled;
            set
            {
                //if enabled would not change, do nothing
                if (_enabled == value) return;

                _enabled = value;
                //if value is true, call OnEnabled
                if (_enabled)
                    OnEnable();
                //if value is false, call OnDisable
                else
                    OnDisable();
            }
        }

        public Collider Collider { get; set; }

        public string Name { get; set; }

        public Transform2D Transform { get; protected set; }

        public Actor(string name = "Actor")
        {
            Name = name;
            Transform = new Transform2D(this);
        }

        public static Actor Instantaite(Actor actor, Transform2D parent = null, Vector2 position = new Vector2(), float rotation = 0, string Name = "Actor")
        {
            //set actor transform values
            actor.Transform.LocalPosition = position;
            actor.Transform.Rotate(rotation);
            actor.Name = Name;
            if (parent != null)
                parent.AddChild(actor.Transform);

            //add actor to current scene
            Game.CurrentScene.AddActor(actor);

            return actor;
        } 

        public static void Destroy(Actor actor)
        {
            //remove all children
            foreach (Transform2D child in actor.Transform.Children)
            {
                actor.Transform.RemoveChild(child);
            }

            if (actor.Transform.Parent != null)
                actor.Transform.Parent.RemoveChild(actor.Transform);

            Game.CurrentScene.RemoveActor(actor);
        }

        public virtual void OnEnable() { }
        public virtual void OnDisable() { }

        public Actor()
        {
            Transform = new Transform2D(this);
        }
        public virtual void Start() 
        {
            _started = true;
        }

        public virtual void Update(double deltaTime) { }

        public virtual void End() { }

        public virtual void OnCollision(Actor other)
        {

        }
    }
}
