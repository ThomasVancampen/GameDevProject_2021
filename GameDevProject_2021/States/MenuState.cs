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
        private Texture2D _buttonTexture;

        private List<Button> _buttons;
        public MenuState(Game1 game, ContentManager contentManager) : base(game, contentManager) 
        {
        
        }
        public override void LoadContent()
        {
            //hier beeindigd
            _buttonTexture = _contentManager.Load<Texture2D>("Buttons/Button");
            _backgroundTexture = _contentManager.Load<Texture2D>("Background/Background");
            _buttons = new List<Button>()
            {
                new Button(_buttonTexture)
                {
                    Position = new Vector2(1080/2, 100),
                    Click = new EventHandler(Button_Quit_Clicked)
                },
                new Button(_buttonTexture)
                {
                    Position = new Vector2(1080/2, 300),
                    Click = new EventHandler(Button_Play_Clicked)
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
            //spriteBatch.Begin();

            spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), Color.White);
            foreach (var button in _buttons)
            {
                button.Draw(spriteBatch);
            }

            //spriteBatch.End();
        }
    }
}
