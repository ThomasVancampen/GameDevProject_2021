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
        private MouseState _currentMouseState;
        private SpriteFont _font;
        private bool _isHovering;
        private MouseState _previousMouseState;
        private Texture2D _texture;

        public EventHandler Click { get; set; }
        public string Text { get; set; }

        public bool Clicked { get; set; }
        public Vector2 Position { get; set; }

        public Rectangle Rectangle { get { return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); }}

        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            var tempColor = Color.White;
            if (_isHovering)
            {
                tempColor = Color.LightGray;
            }
            spritebatch.Draw(_texture, Position, tempColor);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spritebatch.DrawString(_font, Text,new Vector2(x, y), Color.Black, 0,new Vector2(0, 0), 0, SpriteEffects.None, 0);
            }
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
                    Click?.Invoke(this, new EventArgs());//TODO: opzoeken wat dit exact doet
                }
            }
        }
    }
}
