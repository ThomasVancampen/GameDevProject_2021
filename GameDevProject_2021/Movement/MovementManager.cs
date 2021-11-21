using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Movement
{
    class MovementManager
    {
        public void Move(IMoveable obj)
        {
            Vector2 movement = obj.InputReader.ReadInput();
            var newPosition = obj.Position + (movement *= obj.Speed);
            if (newPosition.X < (800 - 30) && newPosition.X > 0
                && newPosition.Y < (480 - 30) && newPosition.Y > 0)//30 veranderen in variabele
            {
                obj.Position = newPosition;
            }
        }
    }
}
