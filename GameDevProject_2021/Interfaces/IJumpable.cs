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
        public int Speed { get; set; }
        public IInputReader InputReader { get; set; }
        public int JumpSpeed { get; set; }
        public int JumpHeight { get; set; }
        public bool Jump { get; set; }
        public float StartY { get; set; }
        public int MaxJumpHeight { get; set; }
        public InputKeys InputKeys { get; set; }
    }
}
