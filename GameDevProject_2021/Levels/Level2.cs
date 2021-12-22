using GameDevProject_2021.Factories;
using GameDevProject_2021.GameObjects;
using GameDevProject_2021.GameObjects.Actors.Enemies;
using GameDevProject_2021.GameObjects.Actors.Enemies.ShootingEnemies.TreeElf;
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
    class Level2 : ILevel
    {
        public List<GameObject> GameObjects { get; set; }
        public Texture2D BackgroundTexture { get; set; }
        public ContentManager ContentManager { get; set; }

        public Level2(ContentManager cm)
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
            var hunterAnimations = new Dictionary<string, Animation>()
            {

                {"Run", new Animation(ContentManager.Load<Texture2D>("ShootingEnemy/HunterRun"), 8) },
                {"Dead", new Animation(ContentManager.Load<Texture2D>("ShootingEnemy/HunterDead"), 5) },
                {"Shoot", new Animation(ContentManager.Load<Texture2D>("ShootingEnemy/HunterShoot"), 7) },


            };
            var floorTexture = ContentManager.Load<Texture2D>("Floor/WoodFloor");
            var exitTexture = ContentManager.Load<Texture2D>("Exit/Exit");
            var groundTexture = ContentManager.Load<Texture2D>("Ground/Ground");
            var walltexture = ContentManager.Load<Texture2D>("FireWall/FullFireWall");
            BackgroundTexture = ContentManager.Load<Texture2D>("Background/TreeBackground");
            var bulletTexture = ContentManager.Load<Texture2D>("ShootingEnemy/BulletSeed");
            GameObjects = new List<GameObject>()
            {
                GameObjectFactory.CreateControlableAnimatedGameObject("Squirrel", 300, 700, squirrelAnimations, new KeyBoardReader(),new InputKeys(){Left = Keys.Left, Right = Keys.Right, Up = Keys.Up, Down = Keys.None}),
                GameObjectFactory.CreateAnimatedShootingGameObject("TreeElf",620-30,630-60, hunterAnimations, bulletTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",300 ,730, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",400 ,630, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",620 ,630, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",720 ,630, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",200 ,830, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",870 ,530, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",720 ,430, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",620 ,430, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",620 ,230, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",720 ,230, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",820 ,230, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",920 ,230, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",1020 ,230, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",1120 ,230, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",470 ,330, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",1020 ,430, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",1120 ,430, floorTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform",1270 ,330, floorTexture),
                GameObjectFactory.CreateGameObject("Exit",870+exitTexture.Width/2, 230-exitTexture.Height, exitTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform", 0, Game1.ScreenHeight-groundTexture.Height, groundTexture),
                GameObjectFactory.CreateGameObject("StaticPlatform", Game1.ScreenWidth/2, Game1.ScreenHeight-groundTexture.Height, groundTexture),
            };
        }
    }
}
