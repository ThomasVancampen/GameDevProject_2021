using GameDevProject_2021.GameObjects;
using GameDevProject_2021.GameObjects.Actors.Enemies;
using GameDevProject_2021.GameObjects.Actors.Heroes;
using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Managers
{
    class CollisionManager
    {
        public void Collide(Temp obj, List<GameObject> gameObjects)
        {
            foreach (var go in gameObjects)
            {
                if (go is StaticObject)
                {
                    if ((obj.Movement.X > 0 && obj.CollisionDetectionManager.CollisionLeft(obj, go)) ||
                    (obj.Movement.X < 0 && obj.CollisionDetectionManager.CollisionRight(obj, go)))
                    {
                        obj.Movement = new Vector2(0, obj.Movement.Y);
                    }
                    if ((obj.Movement.Y > 0 && obj.CollisionDetectionManager.CollisionTop(obj, go)) ||
                        (obj.Movement.Y < 0 && obj.CollisionDetectionManager.CollisionBottom(obj, go)))
                    {
                        obj.Movement = new Vector2(obj.Movement.X, 0);
                        obj.IsFalling = false;
                        obj.FallHeight = 0;
                    }
                }
                else if (go is FireWall)
                {
                    if ((obj.CollisionDetectionManager.CollisionTop(obj, go)) ||
                        (obj.CollisionDetectionManager.CollisionBottom(obj, go)))
                    {
                        obj.Lives = 0;
                        obj.IsAlive = false;
                    }
                }

                if (!obj.CollisionDetectionManager.CollisionBottom(obj, go) && !obj.Jump)
                {
                    obj.IsFalling = true;
                }
                if (obj.CollisionDetectionManager.CollisionTop(obj, go))
                {
                    obj.IsFalling = true;
                }
            }
        }
    }
}
