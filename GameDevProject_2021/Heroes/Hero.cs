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
        public Vector2 Position { get; set; }
        public IInputReader InputReader { get; set; }
        public Rectangle CollisionRectangle { get { return this.collisionRectangle; } set {this.collisionRectangle = value; } }
        private Rectangle collisionRectangle;
        #endregion
        #region Constructor
        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.heroTexture = texture;
            this.runAnimation = new Animate();
            this.Speed = new Vector2(2, 2);
            this.movementManager = new MovementManager();
            this.InputReader = inputReader;
            this.collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
            this.textureDirection = 0;
            
            this.runAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 65, 30, 30)));
            this.runAnimation.AddFrame(new AnimationFrame(new Rectangle(35, 65, 30, 30)));
            this.runAnimation.AddFrame(new AnimationFrame(new Rectangle(65, 65, 30, 30)));
            this.runAnimation.AddFrame(new AnimationFrame(new Rectangle(95, 65, 30, 30)));
            this.runAnimation.AddFrame(new AnimationFrame(new Rectangle(125, 65, 30, 30)));

            this.Position = new Vector2(10, 480 - runAnimation.CurrentFrame.RectangleSource.Height);//startpositie
        }
        #endregion
        #region Methods

        public void Update(GameTime gameTime)
        {
            Move();
            runAnimation.Update(gameTime);

            collisionRectangle.X = (int)Position.X;
            collisionRectangle.Y = (int)Position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.heroTexture, this.Position, this.runAnimation.CurrentFrame.RectangleSource, Color.White,0, Vector2.Zero, 1, this.TextureDirection, 0);//hier kunnen we scalen en flippen
        }
        public void Move()
        {
            movementManager.Move(this);
        }
        #endregion
    }
}
