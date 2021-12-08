using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.Movement;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameDevProject_2021.GameObjects.Actors.Enemies
{
    class ShootingEnemy : Enemy
    {
        public float RunDistance { get; set; }
        public float RunDistanceCounter { get; set; }

        public bool IsShooting { get; set; }


        public ShootingEnemy(Dictionary<string, Animation> hunterAnimations)
        {
            this.Animations = hunterAnimations;
            this.AnimationManager = new AnimationManager(Animations.First().Value);
            this._movementManager = new MovementManager();
            this.RunDistance = 161;
            this.RunDistanceCounter = RunDistance;
            this.Speed = 0.5f;
            this.IsShooting = false;
        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            base.Update(gameTime, gameObjects);
            Move(gameObjects);
            
            if (gameTime.TotalGameTime.Seconds%4 == 0)
            {
                AnimationManager.Play(Animations["Shoot"]);
                this.Movement = Vector2.Zero;
                this.IsShooting = true;
            }
            else
            {
                AnimationManager.Play(Animations["Run"]);
                this.IsShooting = false;
            }

            AnimationManager.Update(gameTime);
            this.Position += this.Movement;
            this.Movement = Vector2.Zero;

        }

        public void Move(List<GameObject> gameObjects)
        {
            _movementManager.Move(this, gameObjects);
        }
    }
}
