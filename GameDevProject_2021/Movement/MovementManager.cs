using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Movement
{
    class MovementManager
    {
        public void Move(IMoveable obj)//obj niet de perfecte naam
        {
            Vector2 movement = obj.InputReader.ReadInput();
            var newPosition = obj.Position + (movement *= obj.Speed);

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
