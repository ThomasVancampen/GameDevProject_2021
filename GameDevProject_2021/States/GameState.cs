using GameDevProject_2021.GameObjects;
using GameDevProject_2021.GameObjects.Actors.Enemies;
using GameDevProject_2021.GameObjects.Actors.Heroes;
using GameDevProject_2021.GameObjects.StaticObjects.StaticEnemy;
using GameDevProject_2021.Model;
using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.Model.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.States
{
    class GameState : State
    {
        private List<GameObject> _gameObjects;
        private Texture2D _backgroundTexture;
        public GameState(Game1 game, ContentManager contentManager) : base(game, contentManager)
        {

        }
        public void Initialize()
        {
            InitializeGameObject();
        }
        private void InitializeGameObject()
        {
            var heroAnimations = new Dictionary<string, Animation>()
            {
                {"Idle", new Animation(_contentManager.Load<Texture2D>("Squirrel/SquirrelIdle"), 6) },
                {"Walk", new Animation(_contentManager.Load<Texture2D>("Squirrel/SquirrelRun"), 8) },
                {"Jump", new Animation(_contentManager.Load<Texture2D>("Squirrel/SquirrelJump"), 4) },
                {"Dead", new Animation(_contentManager.Load<Texture2D>("Squirrel/SquirrelDead"), 4) },

            };
            var hunterAnimations = new Dictionary<string, Animation>()
            {

                {"Run", new Animation(_contentManager.Load<Texture2D>("ShootingEnemy/HunterRun"), 8) },
                {"Dead", new Animation(_contentManager.Load<Texture2D>("ShootingEnemy/HunterDead"), 5) },
                {"Shoot", new Animation(_contentManager.Load<Texture2D>("ShootingEnemy/HunterShoot"), 7) },
                
                
            };
            var floorTexture = _contentManager.Load<Texture2D>("Floor/WoodFloor");
            var exitTexture = _contentManager.Load<Texture2D>("Exit/Exit");
            var groundTexture = _contentManager.Load<Texture2D>("Ground/Ground");
            var walltexture = _contentManager.Load<Texture2D>("FireWall/FullFireWall");
            _backgroundTexture = _contentManager.Load<Texture2D>("Background/TreeBackground");
            var flameAnimations = new Dictionary<string, Animation>()
            {
                {"Idle", new Animation(_contentManager.Load<Texture2D>("Trapp/FireTrapp"), 4) }
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

                new ShootingEnemy(hunterAnimations)
                {
                    Position = new Vector2(620-30,630-60)
                },
                new Trapp(flameAnimations)
                {
                    Position = new Vector2(200, 400)
                },     
                new StaticObject(floorTexture)
                {
                    Position = new Vector2(200, 830)
                },
                new StaticObject(floorTexture)
                {
                    Position = new Vector2(300, 730)
                },
                new StaticObject(floorTexture)
                {
                    Position = new Vector2(400, 630)
                },
                new StaticObject(floorTexture)
                {
                    Position = new Vector2(620, 630)
                },
                new StaticObject(floorTexture)
                {
                    Position = new Vector2(720, 630)
                },
                new StaticObject(floorTexture)
                {
                    Position = new Vector2(870, 530)
                },
                new StaticObject(floorTexture)
                {
                    Position = new Vector2(720, 430)
                },
                new StaticObject(exitTexture)
                {
                    Position = new Vector2(720+exitTexture.Width/2, 430-exitTexture.Height)
                },
                new FireWall(walltexture)
                {
                    Position = new Vector2(0,Game1.ScreenHeight)
                },
                new FireWall(walltexture)
                {
                    Position = new Vector2(walltexture.Width,Game1.ScreenHeight)
                },
                new FireWall(walltexture)
                {
                    Position = new Vector2(walltexture.Width*2,Game1.ScreenHeight)
                },
                new FireWall(walltexture)
                {
                    Position = new Vector2(0,Game1.ScreenHeight+walltexture.Height-20)
                },
                new FireWall(walltexture)
                {
                    Position = new Vector2(walltexture.Width,Game1.ScreenHeight+walltexture.Height-20)
                },
                new FireWall(walltexture)
                {
                    Position = new Vector2(walltexture.Width*2,Game1.ScreenHeight+walltexture.Height-20)
                },
                new StaticObject(groundTexture)
                {
                    Position = new Vector2(0, Game1.ScreenHeight-groundTexture.Height)
                },
                new StaticObject(groundTexture)
                {
                    Position = new Vector2(Game1.ScreenWidth/2, Game1.ScreenHeight-groundTexture.Height)
                },
            };
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), Color.White);
            foreach (var go in _gameObjects)
            {
                go.Draw(spriteBatch);
            }
        }

        public override void LoadContent()
        {
            this.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var go in _gameObjects)
            {
                //Life test
                //if(go is Temp)
                //{
                //    var temp =  go as Temp;
                //    if (!temp.IsAlive)
                //    {
                //        _game.changeState(new GameOverState(_game, _contentManager)
                //        {
                //        });
                //    }
                //}
                go.Update(gameTime, _gameObjects);
            }
        }
    }
}
