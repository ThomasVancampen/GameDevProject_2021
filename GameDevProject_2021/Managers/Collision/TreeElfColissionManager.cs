using GameDevProject_2021.GameObjects;
using GameDevProject_2021.GameObjects.Actors.Enemies;
using GameDevProject_2021.GameObjects.Actors.Heroes;
using GameDevProject_2021.GameObjects.StaticObjects.StaticEnemy;
using GameDevProject_2021.GameObjects.StaticObjects.StaticExit;
using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Managers.Collision
{
    class TreeElfColissionManager : ICollideable
    {
        #region Methods
        public void Collide(GameObject obj1, List<GameObject> gameObjects, GameTime gameTime)
        {
            var obj = obj1 as ShootingEnemy;
            foreach (var go in gameObjects)
            {
                if (go is Hero)
                {
                    if ((obj.Movement.X > 0 && obj.CollisionDetectionManager.CollisionLeft(obj, go)) ||
                    (obj.Movement.X < 0 && obj.CollisionDetectionManager.CollisionRight(obj, go)))
                    {
                        obj.CanMove = false;
                    }
                    else
                    {
                        obj.CanMove = true;
                    }

                }
            }
        }
        #endregion
    }
}
