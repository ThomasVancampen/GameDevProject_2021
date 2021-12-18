using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.States
{
    public abstract class State
    {
        #region Var and Prop
        protected Game1 _game;
        protected ContentManager _contentManager;
        protected int _currentLevel;
        protected int _amountOfLevels;
        #endregion

        #region Constructor
        public State(Game1 game, ContentManager cm, int currentLevel)
        {
            this._game = game;
            this._contentManager = cm;
            this._currentLevel = currentLevel;
            this._amountOfLevels = 2;
        }
        #endregion

        #region Methods
        public abstract void Update(GameTime gameTime);
        public abstract void LoadContent();
        public abstract void Draw(SpriteBatch spriteBatch);

        #endregion
    }
}
