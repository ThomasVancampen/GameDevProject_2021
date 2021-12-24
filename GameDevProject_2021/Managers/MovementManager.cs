using GameDevProject_2021.Interfaces;
using GameDevProject_2021.GameObjects.Actors.Enemies;
using GameDevProject_2021.GameObjects.Actors.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject_2021.GameObjects;

namespace GameDevProject_2021.Managers
{
    class MovementManager
    {
        #region Methods
        public void Move(FireWall obj)
        {
            obj.Movement += new Vector2(0, -obj.Speed);
            obj.Position += obj.Movement;
            obj.Movement = Vector2.Zero;
        }

        public void Move(TreeElfBullet obj)
        {


            if (obj.TravelDistanceCounter >= 0)
            {
                obj.Movement += new Vector2(obj.Speed, 0);
                obj.TravelDistanceCounter -= obj.BulletSpeed;
                if (obj.TravelDistanceCounter >= obj.TravelDistance ||  obj.TravelDistanceCounter <= 0)
                {
                    obj.Exists = false;
                }
            }
            obj.Position += obj.Movement;
            obj.Movement = Vector2.Zero;
        }

        public void Move(ShootingEnemy obj)
        {
            obj.Movement += new Vector2(obj.Speed, 0);

            var futurePosition = obj.Position + obj.Movement;


            if ((obj.RunDistanceCounter >= 0 && obj.RunDistanceCounter <= obj.RunDistance)&& !obj.IsShooting)
            {
                obj.Movement += new Vector2(obj.Speed, 0);
                obj.RunDistanceCounter -= obj.Speed;
                if (obj.RunDistanceCounter >= obj.RunDistance || obj.RunDistanceCounter <= 0)
                {
                    obj.Speed *= -1;
                }
            }

            if (futurePosition.X > obj.Position.X)
            {
                obj.AnimationManager.TextureDirection = SpriteEffects.None;
                obj.IsGoingRight = true;
            }
            if (futurePosition.X < obj.Position.X)
            {
                obj.AnimationManager.TextureDirection = SpriteEffects.FlipHorizontally;
                obj.IsGoingRight = false;
            }

        }

        public void Move(Squirrel obj)
        {
            obj.Movement = obj.InputReader.ReadInput(obj);
            var futurePosition = obj.Position + obj.Movement;
            var temp = obj.Movement;
            //http://flatformer.blogspot.com/2010/02/making-character-jump-in-xnac-basic.html
            //We hebben hier het jump algorithme over genomen en aangepast zodat het werkt voor onze applicatie.
            if (obj.IsJumping && !obj.IsFalling)
            {
                temp.Y += obj.JumpHeight;
                obj.JumpHeight += obj.Gravity;
                
                if (obj.JumpHeight>=0)
                {
                    obj.IsJumping = false;
                    obj.IsFalling = true;
                }
            }
            else
            {
                obj.JumpHeight = obj.MaxJumpHeight;
            }
            if (obj.IsFalling)
            {
                    temp.Y += obj.FallHeight;
                    obj.FallHeight += obj.Gravity;
            }
            obj.Movement = temp;

            if (futurePosition.X > obj.Position.X)
            {
                obj.AnimationManager.TextureDirection = SpriteEffects.None;
            }
            if (futurePosition.X < obj.Position.X)
            {
                obj.AnimationManager.TextureDirection = SpriteEffects.FlipHorizontally;
            }
        }
        #endregion
    }
}
