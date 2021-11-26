using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Model.Animation1;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.GameObjects
{
    abstract class GameObject : ICollide
    {
        public Vector2 Position { get; set; }
        public Animation Animation { get; set; }
        public Rectangle CollisionRectangle { get; set; }
    }
}
