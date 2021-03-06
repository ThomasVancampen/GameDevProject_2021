using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDevProject_2021.Managers.Collision;

namespace GameDevProject_2021.GameObjects.Actors.Heroes
{
    class Squirrel : Hero
    {
        #region Var and Prop
        #endregion
        #region Constuctor
        public Squirrel(Dictionary<string, Animation> animations, IInputReader inputReader) : base(animations, inputReader)
        {
            InitializeSquirrel();
        }
        #endregion
        #region Methods
        private void InitializeSquirrel()
        {
            this.CollisionManager = new SquirrelCollisionManager();
            this.Speed = 4;
            this.MaxJumpHeight = -14;
            this.Gravity = 1;
            this.FallHeight = 0;
            this.Lives = 3;
            this.InvincibleStartTimer = 1;
            this.InvincibleTime = this.InvincibleStartTimer;

        }
        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            this.CollisionRectangle = new Rectangle((int)Position.X + AnimationManager.Animation.FrameWidth - 19, (int)Position.Y + AnimationManager.Animation.FrameHeight, 32, 32);
            Move();
            this.CollisionManager.Collide(this, gameObjects, gameTime);

            //if (!this.IsAlive)
            //{
            //    AnimationManager.Play(Animations["Dead"]);
            //}
            if (Movement.X == 0 && Movement.Y == 0)//TODO: checks moeten beter eventueel jump er in vermengen
            {
                AnimationManager.Play(Animations["Idle"]);
            }
            else if (Movement.Y != 0)
            {
                AnimationManager.Play(Animations["Jump"]);
            }
            else if (Movement.X != 0)
            {
                AnimationManager.Play(Animations["Walk"]);
            }

            if(((int)Position.X + AnimationManager.Animation.FrameWidth - 19)+Movement.X<=0 ||((int)Position.X + AnimationManager.Animation.FrameWidth - 19)+Movement.X >= 1700)//texture width moet er nog bij geteld worden.
            {
                this.Movement = new Vector2(0, this.Movement.Y);
            }
            Position += Movement;
            Movement = Vector2.Zero;
            if (this.Lives <=0)
            {
                this.Exists = false;
            }
            AnimationManager.Update(gameTime);//na dood moet nog 4 keer updaten
        }
        public override void Move()
        {
            _movementManager.Move(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (AnimationManager != null)
            {
                AnimationManager.Draw(spriteBatch);
            }
        }
        #endregion
    }
}
