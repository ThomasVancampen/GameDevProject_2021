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
            var heroAnimations = new Dictionary<string, Animation>()
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
            var flameAnimations = new Dictionary<string, Animation>()
            {
                {"Idle", new Animation(ContentManager.Load<Texture2D>("Trapp/FireTrapp"), 4) }
            };
            GameObjects = new List<GameObject>()
            {
                new Squirrel(heroAnimations, new KeyBoardReader())
                {
                    InputKeys = new InputKeys()
                    {
                        Left = Keys.Left,
                        Right = Keys.Right,
                        Up = Keys.Up,
                        Down = Keys.None
                    },
                    Position = new Vector2(250, 700)
                },
                //new Temp(heroAnimations, new KeyBoardReader())
                //{
                //    InputKeys = new InputKeys()
                //    {
                //        Left = Keys.Q,
                //        Right = Keys.D,
                //        Up = Keys.Z,
                //        Down = Keys.None
                //    },
                //    Position = new Vector2(0, 0)
                //},

                new ShootingEnemy(hunterAnimations, bulletTexture)
                {
                    Position = new Vector2(620-30,630-60)
                },
                //new FireTrapp(flameAnimations)
                //{
                //    Position = new Vector2(650, 630-50)
                //},
                new StaticPlatform(floorTexture)
                {
                    Position = new Vector2(200, 830)
                },
                new StaticPlatform(floorTexture)
                {
                    Position = new Vector2(300, 730)
                },
                new StaticPlatform(floorTexture)
                {
                    Position = new Vector2(400, 630)
                },
                new StaticPlatform(floorTexture)
                {
                    Position = new Vector2(620, 630)
                },
                new StaticPlatform(floorTexture)
                {
                    Position = new Vector2(720, 630)
                },
                new StaticPlatform(floorTexture)
                {
                    Position = new Vector2(870, 530)
                },
                new StaticPlatform(floorTexture)
                {
                    Position = new Vector2(720, 430)
                },
                new Exit(exitTexture)
                {
                    Position = new Vector2(720+exitTexture.Width/2, 430-exitTexture.Height)
                },
                //new FireWall(walltexture)
                //{
                //    Position = new Vector2(0,Game1.ScreenHeight)
                //},
                //new FireWall(walltexture)
                //{
                //    Position = new Vector2(walltexture.Width,Game1.ScreenHeight)
                //},
                //new FireWall(walltexture)
                //{
                //    Position = new Vector2(walltexture.Width*2,Game1.ScreenHeight)
                //},
                //new FireWall(walltexture)
                //{
                //    Position = new Vector2(0,Game1.ScreenHeight+walltexture.Height-20)
                //},
                //new FireWall(walltexture)
                //{
                //    Position = new Vector2(walltexture.Width,Game1.ScreenHeight+walltexture.Height-20)
                //},
                //new FireWall(walltexture)
                //{
                //    Position = new Vector2(walltexture.Width*2,Game1.ScreenHeight+walltexture.Height-20)
                //},
                new StaticPlatform(groundTexture)
                {
                    Position = new Vector2(0, Game1.ScreenHeight-groundTexture.Height)
                },
                new StaticPlatform(groundTexture)
                {
                    Position = new Vector2(Game1.ScreenWidth/2, Game1.ScreenHeight-groundTexture.Height)
                },
            };
        }
    }
}
