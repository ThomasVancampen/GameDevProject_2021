using GameDevProject_2021.Interfaces;
using GameDevProject_2021.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject_2021.Movement;

namespace GameDevProject_2021.GameObjects.Actors
{
    abstract class Actor : GameObject
    {
        #region Var and Prop
        public float Speed { get; set; }
        protected MovementManager _movementManager;
        public bool IsAlive { get; set; }
        #endregion

        #region Constructors
        public Actor()
        {
            IsAlive = true;
        }
        #endregion
    }
}
