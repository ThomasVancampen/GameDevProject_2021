using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Animation
{
    public class AnimationFrame
    {
        public Rectangle RectangleSource { get; set; }

        public AnimationFrame(Rectangle rectangle)
        {
            this.RectangleSource = rectangle;
        }
    }
}
