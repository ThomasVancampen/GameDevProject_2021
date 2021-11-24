using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Collision
{
    class CollisionManager
    {
        public bool CollisionCheck(Rectangle r1, Rectangle r2)
        {
            if (r1.Intersects(r2))
            {
                return true;
            }
            return false;
        }
    }
}
