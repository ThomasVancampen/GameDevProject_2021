using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject_2021.Model;
using System.Linq;

namespace GameDevProject_2021.GameObjects.Actors
{
    class Hero : Actor, IGameObject, IJumpable
    {
        #region Var and Prop
        public InputKeys InputKeys { get; set; }


        public int JumpSpeed { get; set; } = 1;
        public int JumpHeight { get; set; }
        public bool Jump { get; set; } = false;
        public float StartY { get; set; }
        public int MaxJumpHeight { get; set; }
        public IInputReader InputReader { get; set; }



        #endregion
        #region Constructor
        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.Texture = texture;
            this.movementManager = new MovementManager();
            this.InputReader = inputReader;
            this.Speed = 4;
            this.StartY = -1;
            this.MaxJumpHeight = -14;
        }
        public Hero(Dictionary<string, Animation> animations, IInputReader inputReader)
        {
            this.Animations = animations;
            this.AnimationManager = new AnimationManager(Animations.First().Value);
            this.movementManager = new MovementManager();
            this.InputReader = inputReader;
            this.Speed = 4;
            this.StartY = -1;
            this.MaxJumpHeight = -14;
        }
        #endregion
        #region Methods

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            Move();
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);//waarde veranderen voor size van collisionbox

            if(Movement.X == 0 && Movement.Y == 0)
            {
                AnimationManager.Play(Animations["Idle"]);
            }
            else if (Movement.X != 0)
            {
                AnimationManager.Play(Animations["Walk"]);
            }
            else if (Movement.Y != 0)
            {
                AnimationManager.Play(Animations["Jump"]);
            }
            AnimationManager.Update(gameTime);

            foreach (var go in gameObjects)
            {
                if ((this.Movement.X > 0 && this.CollisionManager.CollisionLeft(this, go)) ||
                    (this.Movement.X < 0 && this.CollisionManager.CollisionRight(this, go)))
                {
                    this.Movement = new Vector2(0, this.Movement.Y);
                }
                if ((this.Movement.Y > 0 && this.CollisionManager.CollisionTop(this, go)) ||
                    (this.Movement.Y < 0 && this.CollisionManager.CollisionBottom(this, go)))
                {
                    this.Movement = new Vector2(this.Movement.X, 0);
                    this.Jump = false;
                }
            }
            //Geen border check meer
            this.Position += this.Movement;
            this.Movement = Vector2.Zero;
        }

        //public override void Draw(SpriteBatch spriteBatch)
        //{
        //    spriteBatch.Draw(this.heroTexture, this.Position, null, Color.White,0, Vector2.Zero, 2, this.TextureDirection, 0);
        //}
        public void Move()
        {
            movementManager.Move(this);
        }
        #endregion
    }
}
