using GameDevProject_2021.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.GameObjects.Actors.Enemies
{
    class FireWall : Actor
    {
        public FireWall(Texture2D texture)
        {
            this.Texture = texture;
            this.Speed = 0.1f;
        }
        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            if (Texture != null)
            {
                this.CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
            Move();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
            {
                spriteBatch.Draw(Texture, Position, Color.White);
            }
        }

        public override void Move()
        {
            _movementManager.Move(this);
        }
    }
}
