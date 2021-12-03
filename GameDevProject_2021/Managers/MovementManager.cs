using GameDevProject_2021.Interfaces;
using GameDevProject_2021.GameObjects.Actors.Enemies;
using GameDevProject_2021.GameObjects.Actors.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject_2021.GameObjects;

namespace GameDevProject_2021.Movement
{
    class MovementManager
    {
        #region Methods
        public void Move(Enemy obj, List<GameObject> gameObjects)
        {
            obj.Movement = obj.InputReader.ReadInput(obj);
            var futurePosition = obj.Position + obj.Movement;

            if (futurePosition.X > obj.Position.X)
            {
                obj.AnimationManager.TextureDirection = SpriteEffects.None;
            }
            if (futurePosition.X < obj.Position.X)
            {
                obj.AnimationManager.TextureDirection = SpriteEffects.FlipHorizontally;
            }

            //if (futurePosition.X <= (800 - 30) && futurePosition.X >= 0
            //&& futurePosition.Y <= (480 - 30) && futurePosition.Y >= 0)//30 veranderen in variabele normaalgezien animati.sourcerect.width/heigth uitlezen
            //{
            //        obj.Position = futurePosition;
            //        obj.Movement = Vector2.Zero;
            //}
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
        }
        #endregion
    }
}
