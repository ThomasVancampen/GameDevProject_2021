using GameDevProject_2021.GameObjects;
using GameDevProject_2021.GameObjects.Actors.Enemies;
using GameDevProject_2021.GameObjects.Actors.Enemies.ShootingEnemies.TreeElf;
using GameDevProject_2021.GameObjects.Actors.Heroes;
using GameDevProject_2021.GameObjects.StaticObjects.StaticEnemy;
using GameDevProject_2021.GameObjects.StaticObjects.StaticExit;
using GameDevProject_2021.GameObjects.StaticObjects.StaticPlatform;
using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Model.Animation1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Factories
{
    class GameObjectFactory
    {
        public static GameObject CreateGameObject(string type, int x, int y, Texture2D texture)
        {
            GameObject newObject = null;
            type = type.ToUpper();
            if (type == "FIREWALL")
            {
                newObject = new FireWall(texture) { Position = new Vector2(x, y) };
            }
            if (type == "EXIT")
            {
                newObject = new Exit(texture) { Position = new Vector2(x, y) };
            }
            if (type == "STATICPLATFORM")
            {
                newObject = new StaticPlatform(texture) { Position = new Vector2(x, y) };
            }
            return newObject;
        }
        public static GameObject CreateAnimatedGameObject(string type, int x, int y, Dictionary<string, Animation>animations)
        {
            GameObject newObject = null;
            type = type.ToUpper();
            if (type == "FIRETRAPP")
            {
                newObject = new FireTrapp(animations) { Position = new Vector2(x, y) };
            }
            return newObject;
        }
        public static GameObject CreateAnimatedShootingGameObject(string type, int x, int y, Dictionary<string, Animation> animations, Texture2D bulletTexture)
        {
            GameObject newObject = null;
            type = type.ToUpper();
            if (type == "TREEELF")
            {
                newObject = new TreeElf(animations, bulletTexture) { Position = new Vector2(x, y) };
            }
            return newObject;
        }
        public static GameObject CreateControlableAnimatedGameObject(string type, int x, int y, Dictionary<string, Animation> animations, IInputReader inputReader)
        {
            GameObject newObject = null;
            type = type.ToUpper();
            if (type == "SQUIRREL")
            {
                newObject = new Squirrel(animations, inputReader) { Position = new Vector2(x, y)};
            }
            return newObject;
        }

    }
}
