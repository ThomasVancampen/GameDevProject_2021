using GameDevProject_2021.Managers;
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
        public Rectangle CollisionRectangle { get { return this._collisionRectangle; } set { this._collisionRectangle = value; } }
        private Rectangle _collisionRectangle;
        public bool Exists { get; set; }
        #endregion

        #region Constructor
        public GameObject()
        {
            this.Exists = true;
        }
        #endregion

        #region Methods

        abstract public void Update(GameTime gameTime, List<GameObject> gameObjects); // abstract maken om ervoor te zorgen dat alle kinderen moeten implementere. is implicitet hetzelfde als virutal


        abstract public void Draw(SpriteBatch spriteBatch);
        #endregion
    }
}
