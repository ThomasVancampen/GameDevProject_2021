using GameDevProject_2021.Managers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Interfaces
{
    interface ICollide
    {
        public Rectangle CollisionRectangle { get; set; }
    }
}
