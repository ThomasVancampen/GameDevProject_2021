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
            if (state.IsKeyDown(obj.InputKeys.Left))
            {
                movement.X -= obj.Speed;
            }
            if (state.IsKeyDown(obj.InputKeys.Right))
            {
                movement.X += obj.Speed;
            }
            return movement;
        }
        public Vector2 ReadInput(IJumpable obj)
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 movement = Vector2.Zero;
            if (state.IsKeyDown(obj.InputKeys.Left))
            {
                movement.X -= obj.Speed;
            }
            if (state.IsKeyDown(obj.InputKeys.Right))
            {
                movement.X += obj.Speed;
            }
            if (state.IsKeyDown(obj.InputKeys.Up))
            {
                obj.Jump = true;
            }
            return movement;
        }
    }
}
