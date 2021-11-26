﻿using GameDevProject_2021.Interfaces;
using GameDevProject_2021.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject_2021.Movement;

namespace GameDevProject_2021.GameObjects.Actors
{
    class Actor : GameObject
    {
        public Vector2 Speed { get; set; }
        protected MovementManager movementManager;
        public SpriteEffects TextureDirection { get { return this.textureDirection; } set { this.textureDirection = value; } }
        private SpriteEffects textureDirection;

        public Actor()
        {
            this.Speed = new Vector2(2, 2);
            this.textureDirection = 0;
        }
    }
}
