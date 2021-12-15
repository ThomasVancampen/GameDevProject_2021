using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.Managers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject_2021.GameObjects.Actors.Enemies
{
    class ShootingEnemy : Enemy
    {
        #region prop and var
        public float RunDistance { get; set; }
        public float RunDistanceCounter { get; set; }

        public bool IsShooting { get; set; }
        public int ShootingTimer { get; set; }
        public bool IsGoingRight { get; set; }

        private Texture2D _bulletTexture;

        public List<EnemyBullet> Bullets { get; set; }
        #endregion

        #region constructors
        public ShootingEnemy(Dictionary<string, Animation> hunterAnimations, Texture2D bulletTexture)
        {
            this.Animations = hunterAnimations;
            this.AnimationManager = new AnimationManager(Animations.First().Value);
            this._movementManager = new MovementManager();
            this.RunDistance = 100;
            this.RunDistanceCounter = RunDistance;
            this.Speed = 0.5f;
            this.IsShooting = false;
            this.ShootingTimer = 4;
            this._bulletTexture = bulletTexture;
            this.Bullets = new List<EnemyBullet>();
            this.IsGoingRight = true;
        }
        #endregion

        #region methods
        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            this.CollisionRectangle = new Rectangle((int)Position.X + AnimationManager.Animation.FrameWidth - 19, (int)Position.Y + AnimationManager.Animation.FrameHeight, 32, 32);
            base.Update(gameTime, gameObjects);
            Move(gameObjects);

            if (gameTime.TotalGameTime.Seconds % this.ShootingTimer == 0)
            {
                AnimationManager.Play(Animations["Shoot"]);
                this.Movement = Vector2.Zero;
                this.IsShooting = true;

                if (this.IsShooting && Bullets.Count <= 0 && this.IsGoingRight)
                {

                    Bullets.Add(new EnemyBullet(_bulletTexture)
                    {
                        Position = new Vector2((int)Position.X + AnimationManager.Animation.FrameWidth, (int)Position.Y + AnimationManager.Animation.FrameHeight)
                    });
                }
                else if (this.IsShooting && Bullets.Count <= 0 && !this.IsGoingRight)
                {
                    Bullets.Add(new EnemyBullet(_bulletTexture)
                    {
                        Position = new Vector2((int)Position.X + AnimationManager.Animation.FrameWidth-19, (int)Position.Y + AnimationManager.Animation.FrameHeight)
                    });
                    Bullets[0].Speed *= -1;
                }
            }
            else
            {
                AnimationManager.Play(Animations["Run"]);
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
            this.Position += this.Movement;
            this.Movement = Vector2.Zero;

        }

        public void Move(List<GameObject> gameObjects)
        {
            _movementManager.Move(this, gameObjects);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
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
        #endregion
    }
}
