using GameDevProject_2021.Model.Animation1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameDevProject_2021.GameObjects.StaticObjects.StaticEnemy
{
    class Trapp : StaticObject
    {
        public Trapp(Texture2D texture) : base(texture)
        {
           
        }
        public Trapp(Dictionary<string, Animation> animations) : base(animations)
        {
        }
        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            base.Update(gameTime, gameObjects);
            AnimationManager.Play(Animations["Idle"]);
            AnimationManager.Update(gameTime);
        }
    }
}
