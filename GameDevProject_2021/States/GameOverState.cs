using GameDevProject_2021.Model.ControlButtons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.States
{
    class GameOverState : State
    {
        private Texture2D _backgroundTexture;
        private Texture2D _gameOverTexture;
        private Texture2D _returnTexture;
        private Texture2D _restartTexture;

        private List<Button> _buttons;
        public GameOverState(Game1 game, ContentManager contentManager, int currentLevel) : base(game, contentManager, currentLevel)
        {

        }
        public override void LoadContent()
        {
            _gameOverTexture = _contentManager.Load<Texture2D>("Text/GameOver");
            _returnTexture = _contentManager.Load<Texture2D>("Buttons/ReturnMenuButton");
            _restartTexture = _contentManager.Load<Texture2D>("Buttons/RestartButton");
            _backgroundTexture = _contentManager.Load<Texture2D>("Background/TreeBackground");
            _buttons = new List<Button>()
            {
                new Button(_returnTexture)
                {
                    Position = new Vector2(10, 10),
                    Click = new EventHandler(Button_ReturnMenu_Clicked)
                },
                new Button(_restartTexture)
                {
                    Position = new Vector2(Game1.ScreenWidth / 2 - _restartTexture.Width / 2, Game1.ScreenHeight / 2 + _gameOverTexture.Height),
                    Click = new EventHandler(Button_Restart_Clicked)
                }
            };
        }
        public void Button_ReturnMenu_Clicked(object sender, EventArgs args)
        {
            _game.changeState(new MenuState(_game, _contentManager, _currentLevel)
            {
            });
        }
        public void Button_Restart_Clicked(object sender, EventArgs args)
        {
            _game.changeState(new GameState(_game, _contentManager, _currentLevel)
            {
            });
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var button in _buttons)
            {
                button.Update(gameTime);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), Color.LightGray);
            spriteBatch.Draw(_gameOverTexture, new Vector2(Game1.ScreenWidth/2-_gameOverTexture.Width/2, Game1.ScreenHeight/2-_gameOverTexture.Height/2), Color.White);
            foreach (var button in _buttons)
            {
                button.Draw(spriteBatch);
            }
        }
    }
}
