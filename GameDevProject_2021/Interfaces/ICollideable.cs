using GameDevProject_2021.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Interfaces
{
    interface ICollideable
    {
        public void Collide(GameObject obj, List<GameObject> gameObjects, GameTime gameTime);
    }
}
