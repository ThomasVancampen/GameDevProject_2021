using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.GameObjects.Actors.Enemies
{
    class EnemyBullet : Enemy
    {
        public float TravelDistance { get; set; }
        public float TravelDistanceCounter { get; set; }
        public float BulletSpeed { get; set; }

        public EnemyBullet(Texture2D texture)
        {
            this.Texture = texture;
            this.Speed = 1.8f;
            this.BulletSpeed = 1.8f;
            this.TravelDistance = 250;
            this.TravelDistanceCounter = TravelDistance;
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
