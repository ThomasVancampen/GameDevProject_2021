using GameDevProject_2021.Interfaces;
using GameDevProject_2021.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.GameObjects.Actors
{
    class Actor : ICollide
    {
        public Vector2 Speed { get; set; }
        public SpriteEffects TextureDirection { get { return this.textureDirection; } set { this.textureDirection = value; } }
        private SpriteEffects textureDirection;
        public Vector2 Position { get { return position; } set { position = value; } }
        private Vector2 position;
        public Rectangle CollisionRectangle { get { return this.collisionRectangle; } set { this.collisionRectangle = value; } }
        private Rectangle collisionRectangle;

        public Actor()
        {
            this.Speed = new Vector2(2, 2);
            this.textureDirection = 0;
            this.Position = new Vector2(10, 480 - 32);//nog veranderen naar variabele waarde
            this.collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
        }
    }
}
