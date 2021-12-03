using GameDevProject_2021.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Interfaces
{
    interface IJumpable
    {
        public Vector2 Position { get; set; }
        public Vector2 Movement { get; set; }
        public float Speed { get; set; }
        public int Gravity { get; set; }
        public int JumpHeight { get; set; }
        public bool IsFalling { get; set; }
        public bool Jump { get; set; }
        public int MaxJumpHeight { get; set; }
    }
}
