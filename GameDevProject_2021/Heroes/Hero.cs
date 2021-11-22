using GameDevProject_2021.Animation;
using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Heroes
{
    class Hero : IGameObject, IMoveable, ICollide
    {
        #region Var and Prop

        private Texture2D heroTexture;
        private Animate runAnimation;
        private Animate jumpAnimation;//voor spring mechanisme
        private MovementManager movementManager;
        public SpriteEffects TextureDirection { get { return this.textureDirection; } set { this.textureDirection = value; } }
        private SpriteEffects textureDirection;
        public Vector2 Speed { get; set; }
        public Vector2 Position { get {return position; } set {position = value; } }
        private Vector2 position;
        public IInputReader InputReader { get; set; }
        public Rectangle CollisionRectangle { get { return this.collisionRectangle; } set {this.collisionRectangle = value; } }

        private Rectangle collisionRectangle;
        #endregion
        #region Constructor
        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.heroTexture = texture;
            this.runAnimation = new Animate();
            this.jumpAnimation = new Animate();
            this.Speed = new Vector2(2, 2);
            this.movementManager = new MovementManager();
            this.InputReader = inputReader;
            this.collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
            this.textureDirection = 0;
            
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

            this.Position = new Vector2(10, 480 - runAnimation.CurrentFrame.RectangleSource.Height);//startpositie
        }
        #endregion
        #region Methods

        public void Update(GameTime gameTime)
        {
            Move();
            runAnimation.Update(gameTime);
            jumpAnimation.Update(gameTime);

            collisionRectangle.X = (int)Position.X;
            collisionRectangle.Y = (int)Position.Y;
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
