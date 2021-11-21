using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Input
{
    class KeyBoardReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 movement = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left))
            {
                movement.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                movement.X += 1;
            }
            return movement;
        }
    }
}
