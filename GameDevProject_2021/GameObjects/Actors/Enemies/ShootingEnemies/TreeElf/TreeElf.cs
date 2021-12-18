using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.Managers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject_2021.Managers.Collision;
using GameDevProject_2021.Interfaces;

namespace GameDevProject_2021.GameObjects.Actors.Enemies.ShootingEnemies.TreeElf
{
    class TreeElf : ShootingEnemy
    {
        #region Var and Prop
        #endregion

        #region Constructor
        
        public TreeElf(Dictionary<string, Animation> hunterAnimations, Texture2D bulletTexture) : base(hunterAnimations, bulletTexture)
        {
            InitializeTreeElf();
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            this.CollisionRectangle = new Rectangle((int)Position.X + AnimationManager.Animation.FrameWidth - 19, (int)Position.Y + AnimationManager.Animation.FrameHeight, 32, 32);
            if (this.CanMove)
            {
                Move();
            }
            this.CollisionManager.Collide(this, gameObjects, gameTime);

            if (gameTime.TotalGameTime.Seconds % this.ShootingTimer == 0)
            {
                if (!this.Exists)
                {
                    AnimationManager.Play(Animations["Dead"]);
                }
                AnimationManager.Play(Animations["Shoot"]);
                this.Movement = Vector2.Zero;
                this.IsShooting = true;

                if (this.IsShooting && Bullets.Count <= 0 && this.IsGoingRight)
                {

                    Bullets.Add(new TreeElfBullet(_bulletTexture)
                    {
                        Position = new Vector2((int)Position.X + AnimationManager.Animation.FrameWidth, (int)Position.Y + AnimationManager.Animation.FrameHeight)
                    });
                }
                else if (this.IsShooting && Bullets.Count <= 0 && !this.IsGoingRight)
                {
                    Bullets.Add(new TreeElfBullet(_bulletTexture)
                    {
                        Position = new Vector2((int)Position.X + AnimationManager.Animation.FrameWidth - 19, (int)Position.Y + AnimationManager.Animation.FrameHeight)
                    });
                    Bullets[0].Speed *= -1;
                }
            }
            else
            {
                if (!this.Exists)
                {
                    AnimationManager.Play(Animations["Dead"]);
                }
                else
                {
                    AnimationManager.Play(Animations["Run"]);
                }
                this.IsShooting = false;
            }
            foreach (var bullet in Bullets)
            {
                if (bullet.Exists)
                {
                    bullet.Update(gameTime, gameObjects);

                }
            }

            AnimationManager.Update(gameTime);
            if (this.CanMove)
            {
                this.Position += this.Movement;
                this.Movement = Vector2.Zero;
            }

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (AnimationManager != null)
            {
                AnimationManager.Draw(spriteBatch);
            }
            if (Bullets.Count >= 1)
            {
                foreach (var bullet in Bullets)
                {
                    if (bullet.Exists)
                    {

                        bullet.Draw(spriteBatch);
                    }
                    else
                    {
                        Bullets.RemoveAt(0);
                        break;
                    }
                }
            }
        }
        public override void Move()
        {
            _movementManager.Move(this);
        }
        private void InitializeTreeElf()
        {
            this.RunDistance = 100;
            this.RunDistanceCounter = RunDistance;
            this.Speed = 0.5f;
            this.ShootingTimer = 4;
            this.Bullets = new List<TreeElfBullet>();
            this.CollisionManager = new TreeElfColissionManager();
        }
        #endregion
    }
}
