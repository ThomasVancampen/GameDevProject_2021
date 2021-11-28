﻿using GameDevProject_2021.Collision;
using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Model.Animation1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameDevProject_2021.GameObjects
{
    abstract class GameObject : ICollide, IGameObject
    {
        #region Var and Prop
        public CollisionManager CollisionManager { get; set; }
        public AnimationManager AnimationManager { get; set; }

        public Dictionary<string, Animation> Animations { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get{ return _postion; } 
            set 
            {
                _postion = value;
                if (AnimationManager != null)
                {
                    AnimationManager.Position = _postion;
                }
            ; } 
        }
        protected Vector2 _postion;
        public Vector2 Movement { get; set; }
        public Rectangle CollisionRectangle { get { return this._collisionRectangle; } set { this._collisionRectangle = value; } }
        private Rectangle _collisionRectangle;
        #endregion

        #region Constructors
        public GameObject()
        {
            this.Position = new Vector2(10, 480 - 32);
            this._collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
            this.Movement = Vector2.Zero;
            this.CollisionManager = new CollisionManager();
        }
        #endregion

        #region Methods

        public virtual void Update(GameTime gameTime, List<GameObject> gameObjects) // abstract maken om ervoor te zorgen dat alle kinderen moeten implementere. is implicitet hetzelfde als virutal
        {
            if (Texture != null)
            {
                this.CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
            else if (AnimationManager != null)
            {
                this.CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, this.AnimationManager.Animation.FrameWidth, this.AnimationManager.Animation.FrameHeight);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
            {
                spriteBatch.Draw(Texture, Position, Color.White);
            }
            else if (AnimationManager != null)
            {
                AnimationManager.Draw(spriteBatch);
            }
        }
        #endregion
    }
}
