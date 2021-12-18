using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.GameObjects.StaticObjects.StaticExit
{
    class Exit : StaticObject
    {
        #region Constructor
        public Exit(Texture2D texture) : base(texture) { }
        #endregion

        #region Methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
            {
                spriteBatch.Draw(Texture, Position, Color.White);
            }
        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            if (Texture != null)
            {
                this.CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }
        #endregion
    }
}
