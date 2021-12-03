using GameDevProject_2021.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.GameObjects.Actors.Enemies
{
    class FireWall : Actor
    {
        public FireWall(Texture2D texture)
        {
            this.Texture = texture;
            this.Speed = 0.2f;
            this._movementManager = new MovementManager();
        }
        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            base.Update(gameTime, gameObjects);
            Move(gameObjects);
        }
        public void Move(List<GameObject> gameObjects)
        {
            _movementManager.Move(this, gameObjects);
        }
    }
}
