﻿using GameDevProject_2021.Model;
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
        public Vector2 Speed { get; set; }
        public SpriteEffects TextureDirection { get; set; }
        public IInputReader InputReader { get; set; }
        public InputKeys InputKeys { get; set; }
    }
}
