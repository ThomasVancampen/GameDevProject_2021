using GameDevProject_2021.GameObjects;
using GameDevProject_2021.Model.Animation1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.GameObjects
{
    class StaticObject : GameObject
    {
        public StaticObject(Texture2D texture)
        {
            this.Texture = texture;
        }
        public StaticObject(Dictionary<string, Animation> animations)
        {
            this.Animations = animations;
        }
    }
}
