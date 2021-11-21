﻿using GameDevProject_2021.Animation;
using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Heroes
{
    class Hero : IGameObject, IMoveable
    {
        #region Var and Prop
        private Texture2D heroTexture;
        private Animate animate;
        private MovementManager movementManager;
        public Vector2 Speed { get; set; }
        public Vector2 Position { get; set; }
        public IInputReader InputReader { get; set; }
        #endregion
        public Hero(Texture2D texture, IInputReader inputReader)
        {
            heroTexture = texture;
            animate = new Animate();
            Position = new Vector2(10, 10);//startpositie
            Speed = new Vector2(2, 2);
            movementManager = new MovementManager();
            this.InputReader = inputReader;
            
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
            spriteBatch.Draw(heroTexture, Position, animate.CurrentFrame.RectangleSource, Color.White);
        }
        public void Move()
        {
            movementManager.Move(this);
        }
    }
}
