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

        private List<Button> _buttons;
        public GameOverState(Game1 game, ContentManager contentManager) : base(game, contentManager)
        {

        }
        public override void LoadContent()
        {
            _gameOverTexture = _contentManager.Load<Texture2D>("GameOver/GameOver");
            _returnTexture = _contentManager.Load<Texture2D>("Buttons/ReturnMenuButton");
            _backgroundTexture = _contentManager.Load<Texture2D>("Background/GameBackground");
            _buttons = new List<Button>()
            {
                new Button(_returnTexture)
                {
                    Position = new Vector2(10, 10),
                    Click = new EventHandler(Button_ReturnMenu_Clicked)
                }
            };
        }
        public void Button_ReturnMenu_Clicked(object sender, EventArgs args)
        {
            _game.changeState(new MenuState(_game, _contentManager)
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
