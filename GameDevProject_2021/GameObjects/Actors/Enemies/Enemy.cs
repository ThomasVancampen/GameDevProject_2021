﻿using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.GameObjects.Actors.Enemies
{
    class Enemy : Actor, IMoveable
    {
        #region Var and Prop
        public IInputReader InputReader { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public InputKeys InputKeys { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion
    }
}