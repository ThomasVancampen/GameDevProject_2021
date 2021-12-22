using GameDevProject_2021.Factories;
using GameDevProject_2021.GameObjects;
using GameDevProject_2021.GameObjects.Actors.Enemies;
using GameDevProject_2021.GameObjects.Actors.Heroes;
using GameDevProject_2021.GameObjects.StaticObjects.StaticEnemy;
using GameDevProject_2021.GameObjects.StaticObjects.StaticExit;
using GameDevProject_2021.GameObjects.StaticObjects.StaticPlatform;
using GameDevProject_2021.Interfaces;
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

namespace GameDevProject_2021.Levels
{
    class Level1 : ILevel
    {
        public List<GameObject> GameObjects { get; set; }
        public Texture2D BackgroundTexture { get; set; }
        public ContentManager ContentManager { get; set; }

        public Level1(ContentManager cm)
        {
            this.ContentManager = cm;
        }
        public void Initialize()
        {
            InitializeGameObject();
        }

        private void InitializeGameObject()
        {
            var squirrelAnimations = new Dictionary<string, Animation>()
            {
                {"Idle", new Animation(ContentManager.Load<Texture2D>("Squirrel/SquirrelIdle"), 6) },
                {"Walk", new Animation(ContentManager.Load<Texture2D>("Squirrel/SquirrelRun"), 8) },
                {"Jump", new Animation(ContentManager.Load<Texture2D>("Squirrel/SquirrelJump"), 4) },
                {"Dead", new Animation(ContentManager.Load<Texture2D>("Squirrel/SquirrelDead"), 4) },

            };
            var floorTexture = ContentManager.Load<Texture2D>("Floor/WoodFloor");
            var exitTexture = ContentManager.Load<Texture2D>("Exit/Exit");
            var groundTexture = ContentManager.Load<Texture2D>("Ground/Ground");
            BackgroundTexture = ContentManager.Load<Texture2D>("Background/TreeBackground");
            var flameAnimations = new Dictionary<string, Animation>()
            {
                {"Idle", new Animation(ContentManager.Load<Texture2D>("Trapp/FireTrapp"), 4) }
            };
            GameObjects = new List<GameObject>()
            {
                GameObjectFactory.CreateControlableAnimatedGameObject("Squirrel", 300, 700, squirrelAnimations, new KeyBoardReader(),new InputKeys(){Left = Keys.Left, Right = Keys.Right, Up = Keys.Up, Down = Keys.None}),
                GameObjectFactory.CreateAnimatedGameObject("FireTrapp", 650, 630-50, flameAnimations),
                GameObjectFactory.CreateGameObject("StaticPlatform",300 ,730, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",400 ,630, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",620 ,630, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",720 ,630, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",200 ,830, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",870 ,530, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",720 ,430, floorTexture),
                GameObjectFactory.CreateGameObject("Exit",720+exitTexture.Width/2, 430-exitTexture.Height, exitTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform", 0, Game1.ScreenHeight-groundTexture.Height, groundTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform", Game1.ScreenWidth/2, Game1.ScreenHeight-groundTexture.Height, groundTexture),
            };
        }
    }
}
