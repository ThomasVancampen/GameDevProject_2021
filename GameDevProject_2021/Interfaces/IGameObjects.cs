using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Interfaces
{
    interface IGameObjects
    {
        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
