﻿using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Movement
{
    class MovementManager
    {
        public void Move(IMoveable obj)
        {
            Vector2 movement = obj.InputReader.ReadInput(obj);
            var newPosition = obj.Position + (movement *= obj.Speed);


            if (obj.Jump)
            {
                newPosition.Y += obj.JumpHeight;
                obj.JumpHeight += obj.JumpSpeed;
                if (!(obj.StartY >= newPosition.Y))
                {
                    obj.Jump = false;
                }
            }
            else
            {
                obj.StartY = obj.Position.Y;
                obj.JumpHeight = obj.MaxJumpHeight;
            }





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
            }
        }
    }
}
