using GameDevProject_2021.GameObjects;
using GameDevProject_2021.GameObjects.Actors;
using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Managers.Collision
{
    class CollisionDetectionManager
    {
        #region Methods
        //deze oplossing hebben we gevonden op youtube, maar dit hadden we moeilijk anders kunnen verwoorden
        //https://www.youtube.com/watch?v=CV8P9aq2gQo&list=PLV27bZtgVIJqoeHrQq6Mt_S1-Fvq_zzGZ&index=9
        public bool CollisionLeft(Actor obj1, GameObject obj2)
        {
            return obj1.CollisionRectangle.Right + obj1.Movement.X > obj2.CollisionRectangle.Left &&
                    obj1.CollisionRectangle.Left < obj2.CollisionRectangle.Left && 
                    obj1.CollisionRectangle.Bottom > obj2.CollisionRectangle.Top &&
                    obj1.CollisionRectangle.Top < obj2.CollisionRectangle.Bottom; 
        }
        public bool CollisionRight(Actor obj1, GameObject obj2)
        {
            return obj1.CollisionRectangle.Left + obj1.Movement.X < obj2.CollisionRectangle.Right &&
                    obj1.CollisionRectangle.Right > obj2.CollisionRectangle.Right &&
                    obj1.CollisionRectangle.Bottom > obj2.CollisionRectangle.Top &&
                    obj1.CollisionRectangle.Top < obj2.CollisionRectangle.Bottom;
        }
        public bool CollisionTop(Actor obj1, GameObject obj2)
        {
            return obj1.CollisionRectangle.Bottom + obj1.Movement.Y > obj2.CollisionRectangle.Top &&
                    obj1.CollisionRectangle.Top < obj2.CollisionRectangle.Top &&
                    obj1.CollisionRectangle.Right > obj2.CollisionRectangle.Left &&
                    obj1.CollisionRectangle.Left < obj2.CollisionRectangle.Right;
        }
        public bool CollisionBottom(Actor obj1, GameObject obj2)
        {
            return obj1.CollisionRectangle.Top + obj1.Movement.Y < obj2.CollisionRectangle.Bottom &&
                    obj1.CollisionRectangle.Bottom > obj2.CollisionRectangle.Bottom &&
                    obj1.CollisionRectangle.Right > obj2.CollisionRectangle.Left &&
                    obj1.CollisionRectangle.Left < obj2.CollisionRectangle.Right;
        }
        #endregion
    }
}
