using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.GameObjects.Actors.Enemies
{
    class TreeElfBullet : Enemy
    {
        #region Var and Prop
        public float TravelDistance { get; set; }
        public float TravelDistanceCounter { get; set; }
        public float BulletSpeed { get; set; }
        #endregion

        #region Constuctor

        public TreeElfBullet(Texture2D texture)
        {
            this.Texture = texture;
            this.Speed = 1.8f;
            this.BulletSpeed = 1.8f;
            this.TravelDistance = 250;
            this.TravelDistanceCounter = TravelDistance;
        }
        #endregion

        #region Methods

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            if (Texture != null)
            {
                this.CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
            Move();
        }
        public override void Move()
        {
            _movementManager.Move(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
            {
                spriteBatch.Draw(Texture, Position, Color.White);
            }
        }
        #endregion
    }
}
