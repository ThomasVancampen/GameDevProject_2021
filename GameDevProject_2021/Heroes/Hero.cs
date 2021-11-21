using GameDevProject_2021.Animation;
using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Heroes
{
    class Hero : IGameObject
    {
        private Texture2D heroTexture;
        private Animate animate;

        private Vector2 position;
        private Vector2 speed;

        private IInputReader inputReader;


        public Hero(Texture2D texture, IInputReader inputReader)
        {
            heroTexture = texture;
            animate = new Animate();
            position = new Vector2(10, 10);//startpositie
            speed = new Vector2(2, 2);
            this.inputReader = inputReader;
            
            animate.AddFrame(new AnimationFrame(new Rectangle(0, 65, 30, 30)));
            animate.AddFrame(new AnimationFrame(new Rectangle(35, 65, 30, 30)));
            animate.AddFrame(new AnimationFrame(new Rectangle(65, 65, 30, 30)));
            animate.AddFrame(new AnimationFrame(new Rectangle(95, 65, 30, 30)));
            animate.AddFrame(new AnimationFrame(new Rectangle(125, 65, 30, 30)));


        }

        public void Update(GameTime gameTime)
        { 
            animate.Update(gameTime);
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, position, animate.CurrentFrame.RectangleSource, Color.White);
        }
        public void Move()
        {
            Vector2 movement = inputReader.ReadInput();
            position += (movement *= speed);
            if (position.X<0 || position.X > 800 - animate.CurrentFrame.RectangleSource.Width)
            {
                speed.X *= -1;
            }
            if (position.Y < 0 || position.Y > 480 - animate.CurrentFrame.RectangleSource.Height)
            {
                speed.Y *= -1;
            }
        }
    }
}
