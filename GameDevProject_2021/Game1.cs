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

namespace GameDevProject_2021
{
    public class Game1 : Game
    {
        #region Var and Prop

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D heroTexture;
        private Texture2D tempTexture;

        private Texture2D blokTexture;
        private Rectangle blok;//klasse van maken en hier gewoon texture van maken en in klasse collideRectangle

        private Hero deer;

        private List<GameObject> _gameObjects;

        #endregion
        #region Constructor
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
            heroTexture = Content.Load<Texture2D>("HeroSquirrel");
            tempTexture = Content.Load<Texture2D>("Groot");
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });
        }

        private void InitializeGameObject()
        {
            _gameObjects = new List<GameObject>()
            {
                new Hero(heroTexture, new KeyBoardReader())
                {
                    InputKeys = new InputKeys()
                    {
                        Left = Keys.Left,
                        Right = Keys.Right,
                        Up = Keys.Space,
                        Down = Keys.Down
                    }
                },
                new Hero(tempTexture, new KeyBoardReader())
                {
                    InputKeys = new InputKeys()
                    {
                        Left = Keys.Q,
                        Right = Keys.D,
                        Up = Keys.Z,
                        Down = Keys.Down
                    },
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

            

            //tijdelijke blok
            _spriteBatch.Draw(blokTexture, blok, Color.Red);
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
