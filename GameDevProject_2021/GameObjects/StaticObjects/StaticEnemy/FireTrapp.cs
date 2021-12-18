using GameDevProject_2021.Model.Animation1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameDevProject_2021.GameObjects.StaticObjects.StaticEnemy
{
    class FireTrapp : StaticObject
    {
        #region Constructor
        public FireTrapp(Texture2D texture) : base(texture){}
        public FireTrapp(Dictionary<string, Animation> animations) : base(animations){}
        #endregion

        #region Methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (AnimationManager != null)
            {
                AnimationManager.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            this.CollisionRectangle = new Rectangle((int)Position.X + AnimationManager.Animation.FrameWidth - 19, (int)Position.Y + AnimationManager.Animation.FrameHeight, 32, 32);
            AnimationManager.Play(Animations["Idle"]);
            AnimationManager.Update(gameTime);
        }
        #endregion
    }
}
