using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Interfaces
{
    interface IGameObject
    {
        public Vector2 Position { get; set; }
        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
