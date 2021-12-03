using GameDevProject_2021.GameObjects.Actors;
using GameDevProject_2021.GameObjects.Actors.Heroes;
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
        #region Var and Prop
        private bool _jumpButtonIsUp;
        #endregion

        #region Methods
        //public Vector2 ReadInput(IMoveable obj)
        //{
        //    KeyboardState state = Keyboard.GetState();
        //    Vector2 movement = Vector2.Zero;
        //    if (state.IsKeyDown(obj.InputKeys.Left))
        //    {
        //        movement.X -= obj.Speed;
        //    }
        //    if (state.IsKeyDown(obj.InputKeys.Right))
        //    {
        //        movement.X += obj.Speed;
        //    }
        //    return movement;
        //}
        public Vector2 ReadInput(Hero obj)
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
            if (state.IsKeyDown(obj.InputKeys.Up) && !obj.Jump && _jumpButtonIsUp)
            {
                _jumpButtonIsUp = false;
                obj.Jump = true;
            }
            if (state.IsKeyUp(obj.InputKeys.Up))
            {
                _jumpButtonIsUp = true;
            }
            return movement;
        }
        #endregion
    }
}
