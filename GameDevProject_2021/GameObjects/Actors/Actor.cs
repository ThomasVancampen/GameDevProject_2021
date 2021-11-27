﻿using GameDevProject_2021.Interfaces;
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
        public int Speed { get; set; }
        protected MovementManager _movementManager;
        #endregion

        #region Constructors
        public Actor()
        {
            this.Movement = new Vector2(2, 2);
        }
        #endregion
    }
}
