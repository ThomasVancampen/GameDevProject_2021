using GameDevProject_2021.GameObjects.Actors.Heroes;
using GameDevProject_2021.Managers;
using GameDevProject_2021.Model.Input;
using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using GameDevProject_2021.Model;
using System.Collections.Generic;
using GameDevProject_2021.GameObjects;
using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.GameObjects.StaticObjects.StaticEnemy;
using GameDevProject_2021.GameObjects.Actors.Enemies;
using GameDevProject_2021.States;

namespace GameDevProject_2021
{
    public class Game1 : Game
    {
        #region Var and Prop

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public static int ScreenWidth = 1700;
        public static int ScreenHeight = 950;

        private State _currentState;
        private State _nextState;
        private int _currentLevel;


        #endregion

        #region Constructor
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true; // hier of in initialize
        }
        #endregion

        #region Methods
        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            _currentLevel = 0;

            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentState = new MenuState(this,Content, _currentLevel);
            _currentState.LoadContent();
            _nextState = null;
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();




            if (_nextState != null)
            {
                _currentState = _nextState;
                _currentState.LoadContent();
                _nextState = null;
            }
            _currentState.Update(gameTime);
            base.Update(gameTime);
        }

        public void changeState(State state)
        {
            _nextState = state;
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _currentState.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion
    }
}
