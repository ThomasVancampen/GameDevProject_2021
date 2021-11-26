using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.GameObjects.Actors
{
    class Enemy : IMoveable
    {
        public Vector2 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SpriteEffects TextureDirection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IInputReader InputReader { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
