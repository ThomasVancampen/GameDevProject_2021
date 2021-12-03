﻿using GameDevProject_2021.GameObjects.Actors.Heroes;
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
using GameDevProject_2021.GameObjects.StaticObjects.StaticEnemy;

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
            //_graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            //_graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            //_graphics.ApplyChanges();Niet zeker waar dit moet

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
            var groundTexture = Content.Load<Texture2D>("Ground/Block");
            var groundTexture2 = Content.Load<Texture2D>("Ground/GroundSprite (1)");
            var flameAnimations = new Dictionary<string, Animation>()
            {
                {"Idle", new Animation(Content.Load<Texture2D>("Trapp/NewFlame"), 4) }
            };
            _gameObjects = new List<GameObject>()
            {
                new Temp(heroAnimations, new KeyBoardReader())
                {
                    InputKeys = new InputKeys()
                    {
                        Left = Keys.Left,
                        Right = Keys.Right,
                        Up = Keys.Up,
                        Down = Keys.None
                    },
                    Position = new Vector2(0, 0)
                },
                new Temp(heroAnimations, new KeyBoardReader())
                {
                    InputKeys = new InputKeys()
                    {
                        Left = Keys.Q,
                        Right = Keys.D,
                        Up = Keys.Z,
                        Down = Keys.None
                    },
                    Position = new Vector2(0, 0)
                },
                new Trapp(flameAnimations)
                {
                    Position = new Vector2(200, 340)
                },
                new StaticObject(groundTexture)
                {
                    Position = new Vector2(300, 290)
                },
                new StaticObject(groundTexture2)
                {
                    Position = new Vector2(0, 420)
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
                //var blokTexture = new Texture2D(GraphicsDevice, 1, 1);
                //blokTexture.SetData(new[] { Color.Red });

                //_spriteBatch.Draw(blokTexture, go.CollisionRectangle, Color.Red*0.5f);//TODO: remove hitbox
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion
    }
}
