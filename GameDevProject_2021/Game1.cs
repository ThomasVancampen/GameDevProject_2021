using GameDevProject_2021.GameObjects.Actors;
using GameDevProject_2021.Collision;
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

namespace GameDevProject_2021
{
    public class Game1 : Game
    {
        #region Var and Prop

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<GameObject> _gameObjects;

        #endregion

        #region Constructors
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        #endregion

        #region Methods
        protected override void Initialize()
        {

            base.Initialize();
            InitializeGameObject(); //hier of in loadcontent zoals in video?
        }
        protected override void LoadContent()
        {
            _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            _graphics.ApplyChanges();//Niet zeker waar dit moet

            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        private void InitializeGameObject()
        {
            var heroAnimations = new Dictionary<string, Animation>()
            {
                {"Idle", new Animation(Content.Load<Texture2D>("Squirrel/SquirrelIdle"), 6) },
                {"Walk", new Animation(Content.Load<Texture2D>("Squirrel/SquirrelRun"), 8) },
                {"Jump", new Animation(Content.Load<Texture2D>("Squirrel/SquirrelJump"), 4) },
            };
            _gameObjects = new List<GameObject>()
            {
                new Hero(heroAnimations, new KeyBoardReader())
                {
                    InputKeys = new InputKeys()
                    {
                        Left = Keys.Left,
                        Right = Keys.Right,
                        Up = Keys.Space,
                        Down = Keys.Down
                    }
                }
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            foreach (var go in _gameObjects)
            {
                go.Update(gameTime, _gameObjects);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            foreach (var go in _gameObjects)
            {
                go.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion








        //public void ChangeInput(IInputReader inputReader)
        //{
        //    inputReader = inputReader;
        //}
        //Om input te veranderen in options bvb
    }
}
