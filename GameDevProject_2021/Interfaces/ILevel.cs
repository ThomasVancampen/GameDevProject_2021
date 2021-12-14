using GameDevProject_2021.GameObjects;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Interfaces
{
    interface ILevel
    {
        public List<GameObject> GameObjects { get; set; }
        public Texture2D BackgroundTexture { get; set; }
        public ContentManager ContentManager { get; set; }
        public void Initialize();

    }
}
