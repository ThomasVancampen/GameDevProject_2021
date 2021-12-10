using GameDevProject_2021.Model.ControlButtons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.States
{
    class MenuState : State
    {
        private Texture2D _backgroundTexture;
        private Texture2D _startButtonTexture;
        private Texture2D _exitButtonTexture;

        private List<Button> _buttons;
        public MenuState(Game1 game, ContentManager contentManager) : base(game, contentManager) 
        {
        
        }
        public override void LoadContent()
        {
            _startButtonTexture = _contentManager.Load<Texture2D>("Buttons/StartButton");
            _exitButtonTexture = _contentManager.Load<Texture2D>("Buttons/ExitButton");
            _backgroundTexture = _contentManager.Load<Texture2D>("Background/MenuBackground");
            _buttons = new List<Button>()
            {
                new Button(_startButtonTexture)
                {
                    Position = new Vector2(Game1.ScreenWidth/2, 100),
                    Click = new EventHandler(Button_Play_Clicked)
                },
                new Button(_exitButtonTexture)
                {
                    Position = new Vector2(Game1.ScreenWidth/2, 150),
                    Click = new EventHandler(Button_Quit_Clicked)
                }
            };
        }

        public void Button_Play_Clicked(object sender, EventArgs args)
        {
            _game.changeState(new GameState(_game, _contentManager)
            {
            });
        }
        public void Button_Quit_Clicked(object sender, EventArgs args)
        {
            _game.Exit();
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
            spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), Color.White);
            foreach (var button in _buttons)
            {
                button.Draw(spriteBatch);
            }
        }
    }
}
