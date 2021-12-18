using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Model.ControlButtons
{
    class Button
    {
        #region Var and Prop
        private MouseState _currentMouseState;
        private bool _isHovering;
        private MouseState _previousMouseState;
        public Texture2D Texture { get; }

        public EventHandler Click { get; set; }

        public bool Clicked { get; set; }
        public Vector2 Position { get; set; }

        public Rectangle Rectangle { get { return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); }}
        #endregion

        #region Constructor
        public Button(Texture2D texture)
        {
            Texture = texture;
        }
        #endregion

        #region Methods
        public void Draw(SpriteBatch spritebatch)
        {
            var tempColor = Color.White;
            if (_isHovering)
            {
                tempColor = Color.LightGray;
            }
            spritebatch.Draw(Texture, Position, tempColor);
        }

        public void Update(GameTime gameTime)
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;
                if (_previousMouseState.LeftButton == ButtonState.Pressed && _currentMouseState.LeftButton == ButtonState.Released)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
        #endregion
    }
}
