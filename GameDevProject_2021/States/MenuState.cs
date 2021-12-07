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
        public MenuState(Game1 game, ContentManager contentManager) : base(game, contentManager) 
        {
        
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

        }

        public override void LoadContent()
        {
            
            _backgroundTexture = _contentManager.Load<Texture2D>("Background/Background");

        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
