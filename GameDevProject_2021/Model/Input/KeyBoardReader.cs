using GameDevProject_2021.GameObjects.Actors;
using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Model.Input
{
    class KeyBoardReader : IInputReader
    {
        public Vector2 ReadInput(IMoveable obj)
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
        public Vector2 ReadInput(IJumpable obj)
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
            if (state.IsKeyDown(Keys.Space))
            {
                obj.Jump = true;
            }
            return movement;
        }
    }
}
