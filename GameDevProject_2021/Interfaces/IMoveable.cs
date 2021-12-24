using GameDevProject_2021.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Interfaces
{
    interface IMoveable
    {
        public Vector2 Position { get; set; }
        public Vector2 Movement { get; set; }
        public float Speed { get; set; }
        void Move();
    }
}
