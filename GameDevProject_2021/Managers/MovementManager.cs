using GameDevProject_2021.Interfaces;
using GameDevProject_2021.GameObjects.Actors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Movement
{
    class MovementManager
    {
        public void Move(Enemy obj)
        {
            obj.Movement = obj.InputReader.ReadInput(obj);
            var newPosition = obj.Position + (obj.Movement);
            

            if (newPosition.X > obj.Position.X)
            {
                obj.TextureDirection = SpriteEffects.None;
            }
            if (newPosition.X<obj.Position.X)
            {
                obj.TextureDirection = SpriteEffects.FlipHorizontally;
            }

            if (newPosition.X <= (800 - 30) && newPosition.X >= 0
            && newPosition.Y <= (480 - 30) && newPosition.Y >= 0)//30 veranderen in variabele normaalgezien animati.sourcerect.width/heigth uitlezen
            {
                    obj.Position = newPosition;
                    obj.Movement = Vector2.Zero;
            }
        }
        public void Move(Hero obj)
        {
            obj.Movement = obj.InputReader.ReadInput(obj);
            var futurePosition = obj.Position + obj.Movement;
            var temp = obj.Movement;

            if (obj.Jump)
            {
                if (obj.StartY < 0)
                    obj.StartY = obj.Position.Y;
                temp.Y += obj.JumpHeight;
                obj.JumpHeight += obj.JumpSpeed;
                if (!(obj.StartY >= futurePosition.Y))
                {
                    obj.Jump = false;
                    obj.StartY = -1;
                }
            }
            else
            {
                obj.StartY = obj.Position.Y;
                obj.JumpHeight = obj.MaxJumpHeight;
            }

            if (futurePosition.X > obj.Position.X)
            {
                obj.TextureDirection = SpriteEffects.None;
            }
            if (futurePosition.X < obj.Position.X)
            {
                obj.TextureDirection = SpriteEffects.FlipHorizontally;
            }
            obj.Movement = temp;
        }
    }
}
