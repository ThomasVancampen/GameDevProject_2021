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
            //Dit handige trucje hebben we gevonden op internet om een onderscheid te maken tussen hold en tap
            //https://stackoverflow.com/questions/36961902/monogame-key-pressed-instead-of-
            if (state.IsKeyDown(obj.InputKeys.Up) && !obj.IsJumping && _jumpButtonIsUp)
            {
                _jumpButtonIsUp = false;
                obj.IsJumping = true;
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
