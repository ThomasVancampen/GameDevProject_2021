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
            obj.Position += (movement *= obj.Speed);
        }
    }
}
