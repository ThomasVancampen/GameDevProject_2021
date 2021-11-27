using GameDevProject_2021.Model.Animation1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021
{
    class AnimationManager
    {
        #region Var and Prop
        private Animation _animation;
        private float _timer;
        public Vector2 Position { get; set; }
        public SpriteEffects TextureDirection { get { return this._textureDirection; } set { this._textureDirection = value; } }
        private SpriteEffects _textureDirection;
        #endregion

        #region Consturctors
        public AnimationManager(Animation animation)
        {
            _animation = animation;
            this._textureDirection = 0;
        }
        #endregion

        #region Methods
        public void Play(Animation animation)
        {
            if (_animation == animation)
                return;
            _animation = animation;
            _animation.CurrentFrame = 0;
            _timer = 0f;
        }
        public void Stop()
        {
            _timer = 0f;
            _animation.CurrentFrame = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_animation.Texture, Position, new Rectangle(_animation.CurrentFrame * _animation.FrameWidth, 0, _animation.FrameWidth, _animation.FrameHeight), Color.White, 0, Vector2.Zero, 1, this.TextureDirection, 0);
        }
        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer > _animation.FrameSpeed)
            {
                _timer = 0f;
                _animation.CurrentFrame++;
                if (_animation.CurrentFrame >= _animation.FrameCount)
                {
                    _animation.CurrentFrame = 0;
                }
            }
            
        }
        #endregion

    }
}
