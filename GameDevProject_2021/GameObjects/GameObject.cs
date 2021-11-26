using GameDevProject_2021.Collision;
using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Model.Animation1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.GameObjects
{
    abstract class GameObject : ICollide, IGameObject
    {
        protected CollisionManager collsionManager;
        protected AnimationManager animatieManager;
        public Vector2 Position { get; set; }
        public Animation Animation { get; set; }
        public Rectangle CollisionRectangle { get { return this.collisionRectangle; } set { this.collisionRectangle = value; } }
        private Rectangle collisionRectangle;
        public GameObject()
        {
            this.Position = new Vector2(10, 480 - 32);
            this.collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
        }

        public virtual void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
