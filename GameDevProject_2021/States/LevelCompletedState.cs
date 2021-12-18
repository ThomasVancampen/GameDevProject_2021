using GameDevProject_2021.Model.ControlButtons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.States
{
    class LevelCompletedState : State
    {
        #region Var and Prop
        private Texture2D _backgroundTexture;
        private Texture2D _levelCompletedTexture;
        private Texture2D _returnTexture;
        private Texture2D _nextTexture;

        private List<Button> _buttons;
        #endregion

        #region Constructor
        public LevelCompletedState(Game1 game, ContentManager contentManager, int currentLevel) : base(game, contentManager, currentLevel)
        {

        }
        #endregion

        #region Methods
        public override void LoadContent()
        {
            _levelCompletedTexture = _contentManager.Load<Texture2D>("Text/LevelCompleted");
            _returnTexture = _contentManager.Load<Texture2D>("Buttons/ReturnMenuButton");
            _nextTexture = _contentManager.Load<Texture2D>("Buttons/NextLevelButton");
            _backgroundTexture = _contentManager.Load<Texture2D>("Background/TreeBackground");
            _buttons = new List<Button>()
            {
                new Button(_returnTexture)
                {
                    Position = new Vector2(10, 10),
                    Click = new EventHandler(Button_ReturnMenu_Clicked)
                },
                new Button(_nextTexture)
                {
                    Position = new Vector2(Game1.ScreenWidth / 2 - _nextTexture.Width / 2, Game1.ScreenHeight / 2 + _levelCompletedTexture.Height),
                    Click = new EventHandler(Button_NextLevel_Clicked)
                }
            };
        }
        public void Button_ReturnMenu_Clicked(object sender, EventArgs args)
        {
            //nog bekijken hoe we levels willen doen als we terug naar hoofdmenu gaan
            _game.changeState(new MenuState(_game, _contentManager, _currentLevel));
           
        }
        public void Button_NextLevel_Clicked(object sender, EventArgs args)
        {
            _currentLevel++;
            if (_currentLevel < _amountOfLevels)
            {
                _game.changeState(new GameState(_game, _contentManager, _currentLevel)
                {
                });
            }
            else
                _game.changeState(new GameCompletedState(_game, _contentManager, _currentLevel));

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
            spriteBatch.Draw(_levelCompletedTexture, new Vector2(Game1.ScreenWidth / 2 - _levelCompletedTexture.Width / 2, Game1.ScreenHeight / 2 - _levelCompletedTexture.Height / 2), Color.White);
            foreach (var button in _buttons)
            {
                button.Draw(spriteBatch);
            }
        }
        #endregion
    }
}
