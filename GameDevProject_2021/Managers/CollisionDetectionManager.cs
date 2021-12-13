using GameDevProject_2021.GameObjects;
using GameDevProject_2021.GameObjects.Actors;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Managers
{
    class CollisionDetectionManager
    {
        #region Methods
        //public bool CollisionCheck(Rectangle r1, Rectangle r2)
        //{
        //    if (r1.Intersects(r2))
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        public bool CollisionLeft(GameObject obj1, GameObject obj2)
        {
            return obj1.CollisionRectangle.Right + obj1.Movement.X > obj2.CollisionRectangle.Left &&
                    obj1.CollisionRectangle.Left < obj2.CollisionRectangle.Left && 
                    obj1.CollisionRectangle.Bottom > obj2.CollisionRectangle.Top &&
                    obj1.CollisionRectangle.Top < obj2.CollisionRectangle.Bottom; 
        }
        public bool CollisionRight(GameObject obj1, GameObject obj2)
        {
            return obj1.CollisionRectangle.Left + obj1.Movement.X < obj2.CollisionRectangle.Right &&
                    obj1.CollisionRectangle.Right > obj2.CollisionRectangle.Right &&
                    obj1.CollisionRectangle.Bottom > obj2.CollisionRectangle.Top &&
                    obj1.CollisionRectangle.Top < obj2.CollisionRectangle.Bottom;
        }
        public bool CollisionTop(GameObject obj1, GameObject obj2)
        {
            return obj1.CollisionRectangle.Bottom + obj1.Movement.Y > obj2.CollisionRectangle.Top &&
                    obj1.CollisionRectangle.Top < obj2.CollisionRectangle.Top &&
                    obj1.CollisionRectangle.Right > obj2.CollisionRectangle.Left &&
                    obj1.CollisionRectangle.Left < obj2.CollisionRectangle.Right;
        }
        public bool CollisionBottom(GameObject obj1, GameObject obj2)
        {
            return obj1.CollisionRectangle.Top + obj1.Movement.Y < obj2.CollisionRectangle.Bottom &&
                    obj1.CollisionRectangle.Bottom > obj2.CollisionRectangle.Bottom &&
                    obj1.CollisionRectangle.Right > obj2.CollisionRectangle.Left &&
                    obj1.CollisionRectangle.Left < obj2.CollisionRectangle.Right;
        }
        #endregion
    }
}
