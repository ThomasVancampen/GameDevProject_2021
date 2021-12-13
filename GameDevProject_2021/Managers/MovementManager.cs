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
        //public void Move(Enemy obj, List<GameObject> gameObjects)
        //{
        //    //obj.Movement = obj.InputReader.ReadInput(obj);
        //    var futurePosition = obj.Position + obj.Movement;

        //    if (futurePosition.X > obj.Position.X)
        //    {
        //        obj.AnimationManager.TextureDirection = SpriteEffects.None;
        //    }
        //    if (futurePosition.X < obj.Position.X)
        //    {
        //        obj.AnimationManager.TextureDirection = SpriteEffects.FlipHorizontally;
        //    }
        //}
        public void Move(FireWall obj, List<GameObject> gameObjects)
        {
            obj.Movement += new Vector2(0, -obj.Speed);
            obj.Position += obj.Movement;
            obj.Movement = Vector2.Zero;
        }

        public void Move(ShootingEnemy obj, List<GameObject> gameObjects)
        {
            obj.Movement += new Vector2(obj.Speed, 0);
            
            var futurePosition = obj.Position + obj.Movement;
            

            if ((obj.RunDistanceCounter >=0 || obj.RunDistanceCounter <= obj.RunDistance)&& !obj.IsShooting)
            {
                obj.Movement += new Vector2(obj.Speed, 0);
                obj.RunDistanceCounter -= obj.Speed;
                if (obj.RunDistanceCounter>=obj.RunDistance|| obj.RunDistanceCounter <= 0)
                { 
                    obj.Speed *= -1;
                }
            }

            if (futurePosition.X > obj.Position.X)
            {
                obj.AnimationManager.TextureDirection = SpriteEffects.None;
            }
            if (futurePosition.X < obj.Position.X)
            {
                obj.AnimationManager.TextureDirection = SpriteEffects.FlipHorizontally;
            }
           
        }

        public void Move(Hero obj, List<GameObject> gameObjects)
        {
            obj.Movement = obj.InputReader.ReadInput(obj);
            var futurePosition = obj.Position + obj.Movement;
            var temp = obj.Movement;

            if (obj.Jump && !obj.IsFalling)
            {
                temp.Y += obj.JumpHeight;
                obj.JumpHeight += obj.Gravity;
                
                if (obj.JumpHeight>=0)
                {
                    obj.Jump = false;
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

            foreach (var go in gameObjects)
            {
                if ((obj.Movement.X > 0 && obj.CollisionManager.CollisionLeft(obj, go)) ||
                    (obj.Movement.X < 0 && obj.CollisionManager.CollisionRight(obj, go)))
                {
                    obj.Movement = new Vector2(0, obj.Movement.Y);
                }
                if ((obj.Movement.Y > 0 && obj.CollisionManager.CollisionTop(obj, go)) ||
                    (obj.Movement.Y < 0 && obj.CollisionManager.CollisionBottom(obj, go)))
                {
                    obj.Movement = new Vector2(obj.Movement.X, 0);
                    obj.IsFalling=false;
                    obj.FallHeight = 0;
                }

                if (!obj.CollisionManager.CollisionBottom(obj, go)&&!obj.Jump)
                {
                    obj.IsFalling = true;
                }
                if (obj.CollisionManager.CollisionTop(obj, go))
                {
                    obj.IsFalling = true;
                }
            }
            //if (obj.Position.Y>=400 && !obj.Jump)
            //{
            //    obj.Movement = new Vector2(obj.Movement.X, 0);
            //}
        }
        #endregion
    }
}
