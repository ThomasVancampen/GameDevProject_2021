using GameDevProject_2021.Animation;
using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Hero
{
    class Marcus : IGameObjects
    {
        Texture2D heroTexture;
        Animate animate;

        public Marcus(Texture2D texture)
        {
            heroTexture = texture;
            animate = new Animate();
            
            animate.AddFrame(new AnimationFrame(new Rectangle(0, 65, 30, 30)));
            animate.AddFrame(new AnimationFrame(new Rectangle(35, 65, 30, 30)));
            animate.AddFrame(new AnimationFrame(new Rectangle(65, 65, 30, 30)));
            animate.AddFrame(new AnimationFrame(new Rectangle(95, 65, 30, 30)));
            animate.AddFrame(new AnimationFrame(new Rectangle(125, 65, 30, 30)));


        }

        public void Update(GameTime gameTime)
        {
            animate.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, new Vector2(0, 0), animate.CurrentFrame.RectangleSource, Color.White);
        }
    }
}
