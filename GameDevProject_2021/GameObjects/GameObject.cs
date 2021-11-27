using GameDevProject_2021.Collision;
using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Model.Animation1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GameDevProject_2021.GameObjects
{
    abstract class GameObject : ICollide, IGameObject
    {

        public CollisionManager CollisionManager { get; set; }
        protected AnimationManager animatieManager;
        public Vector2 Position { get; set; }
        public Vector2 Movement { get; set; }
        public Animation Animation { get; set; }
        public Rectangle CollisionRectangle { get { return this.collisionRectangle; } set { this.collisionRectangle = value; } }
        private Rectangle collisionRectangle;
        public GameObject()
        {
            this.Position = new Vector2(10, 480 - 32);
            this.collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
            this.Movement = Vector2.Zero;
            this.CollisionManager = new CollisionManager();
        }

        public virtual void Update(GameTime gameTime, List<GameObject> gameObjects) // abstract maken om ervoor te zorgen dat alle kinderen moeten implementere. is implicitet hetzelfde als virutal
        {
            throw new NotImplementedException();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
