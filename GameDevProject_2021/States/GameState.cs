using GameDevProject_2021.GameObjects;
using GameDevProject_2021.GameObjects.Actors.Enemies;
using GameDevProject_2021.GameObjects.Actors.Heroes;
using GameDevProject_2021.GameObjects.StaticObjects.StaticEnemy;
using GameDevProject_2021.GameObjects.StaticObjects.StaticExit;
using GameDevProject_2021.GameObjects.StaticObjects.StaticLives;
using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Levels;
using GameDevProject_2021.Model;
using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.Model.ControlButtons;
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
        private List<ILevel> _levels;
        private List<Life> _lives;
        public GameState(Game1 game, ContentManager contentManager, int currentLevel) : base(game, contentManager, currentLevel)
        {
            _currentLevel = currentLevel;
        }
        public void Initialize()
        {
            var lifeTexture = _contentManager.Load<Texture2D>("Heart/LifeHeart");
            _lives = new List<Life>()
            {
                new Life(lifeTexture){Position = new Vector2(0,0)},
                new Life(lifeTexture){Position = new Vector2(lifeTexture.Width,0)},
                new Life(lifeTexture){Position = new Vector2(lifeTexture.Width*2,0)}
            };
            _levels = new List<ILevel>()
            {
                new Level1(_contentManager),
                new Level2(_contentManager)
            };
            foreach (var level in _levels)
            {
                level.Initialize();
            }
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_levels[_currentLevel].BackgroundTexture, new Vector2(0, 0), Color.White);
            foreach (var go in _levels[_currentLevel].GameObjects)//de nul moet een variabele worden
            {
                go.Draw(spriteBatch);
            }
            foreach (var life in _lives)
            {
                life.Draw(spriteBatch);
            }
        }

        public override void LoadContent()
        {
            this.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var go in _levels[_currentLevel].GameObjects)
            {
                if(go is Squirrel)
                {
                    var temp =  go as Squirrel;
                    if (temp.Lives !=_lives.Count)
                    {
                        _lives.RemoveAt(_lives.Count - 1);
                    }

                    if (!temp.Exists)
                    {
                        _game.changeState(new GameOverState(_game, _contentManager, _currentLevel)
                        {
                        });
                    }
                    else if (temp.Victorious)
                    {
                        _game.changeState(new LevelCompletedState(_game, _contentManager, _currentLevel)
                        {
                        });
                    }

                }
                go.Update(gameTime, _levels[_currentLevel].GameObjects);
            }
        }
    }
}
