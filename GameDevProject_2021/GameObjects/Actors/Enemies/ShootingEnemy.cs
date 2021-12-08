using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.Movement;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameDevProject_2021.GameObjects.Actors.Enemies
{
    class ShootingEnemy : Enemy
    {
        public ShootingEnemy(Dictionary<string, Animation> hunterAnimations)
        {
            this.Animations = hunterAnimations;
            this.AnimationManager = new AnimationManager(Animations.First().Value);
            this._movementManager = new MovementManager();
        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            base.Update(gameTime, gameObjects);
            AnimationManager.Update(gameTime);
        }

        public void Move(List<GameObject> gameObjects)
        {
            _movementManager.Move(this, gameObjects);
        }
    }
}
