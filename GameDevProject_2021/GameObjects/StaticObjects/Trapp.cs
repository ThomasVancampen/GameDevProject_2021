using GameDevProject_2021.Model.Animation1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameDevProject_2021.GameObjects.StaticObjects
{
    class Trapp : GameObject
    {
        public Trapp(Texture2D texture)
        {
            this.Texture = texture;
        }
        public Trapp(Dictionary<string, Animation> animations)
        {
            this.Animations = animations;
            this.AnimationManager = new AnimationManager(Animations.First().Value);
        }
        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            base.Update(gameTime, gameObjects);
            AnimationManager.Play(Animations["Idle"]);
        }
    }
}
