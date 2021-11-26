using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.GameObjects.Actors
{
    class Hero : Actor, IGameObject, ICollide, IJumpable
    {
        #region Var and Prop

        private Texture2D heroTexture;
        private Animation runAnimation;
        private Animation jumpAnimation;//voor spring mechanisme
        private MovementManager movementManager;


        public int JumpSpeed { get; set; } = 1;
        public int JumpHeight { get; set; }
        public bool Jump { get; set; } = false;
        public float StartY { get; set; }
        public int MaxJumpHeight { get; set; } = -14;
        public IInputReader InputReader { get; set; }



        #endregion
        #region Constructor
        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.heroTexture = texture;
            this.runAnimation = new Animation();
            this.jumpAnimation = new Animation();
            this.movementManager = new MovementManager();
            this.InputReader = inputReader;
            
            this.runAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 65, 32, 30)));//aparte methode voor maken
            this.runAnimation.AddFrame(new AnimationFrame(new Rectangle(32, 65, 32, 30)));
            this.runAnimation.AddFrame(new AnimationFrame(new Rectangle(64, 65, 32, 30)));
            this.runAnimation.AddFrame(new AnimationFrame(new Rectangle(96, 65, 32, 30)));
            this.runAnimation.AddFrame(new AnimationFrame(new Rectangle(128,65, 32, 30)));
            this.runAnimation.AddFrame(new AnimationFrame(new Rectangle(160,65, 32, 30)));
            this.runAnimation.AddFrame(new AnimationFrame(new Rectangle(192, 65, 32, 30)));
            this.runAnimation.AddFrame(new AnimationFrame(new Rectangle(224, 65, 32, 30)));

            this.jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 160, 30, 30)));
            this.jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(32, 160, 30, 30)));
            this.jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(64, 160, 30, 30)));
            this.jumpAnimation.AddFrame(new AnimationFrame(new Rectangle(96, 160, 30, 30)));
        }
        #endregion
        #region Methods

        public void Update(GameTime gameTime)
        {
            Move();
            runAnimation.Update(gameTime);
            jumpAnimation.Update(gameTime);

            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);//waarde veranderen voor size van collisionbox
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.heroTexture, this.Position, this.runAnimation.CurrentFrame.RectangleSource, Color.White,0, Vector2.Zero, 2, this.TextureDirection, 0);//hier kunnen we scalen en flippen
        }
        public void Move()
        {
            movementManager.Move(this);
        }
        #endregion
    }
}
