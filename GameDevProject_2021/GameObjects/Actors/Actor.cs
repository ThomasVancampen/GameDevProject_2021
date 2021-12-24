using GameDevProject_2021.Interfaces;
using GameDevProject_2021.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject_2021.Managers;

namespace GameDevProject_2021.GameObjects.Actors
{
    abstract class Actor : GameObject, IMoveable
    {
        #region Var and Prop
        public float Speed { get; set; }
        protected MovementManager _movementManager;
        public Vector2 Movement { get; set; }
        #endregion

        #region Constructor
        public Actor()
        {
            this._movementManager = new MovementManager();
            this.Movement = Vector2.Zero;
        }
        abstract public void Move();
        #endregion
    }
}
