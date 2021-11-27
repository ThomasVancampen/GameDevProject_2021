using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Model.Animation1
{
    public class Animation
    {
        #region Var and Prop
        public int CurrentFrame { get; set; }

        public int FrameCount { get; set; }
        public int CurrentFrameCount { get; set; }
        public int FrameHeight { get {return Texture.Height; } }
        public float FrameSpeed { get; set; }
        public int FrameWidth { get { return Texture.Width / FrameCount; } }
        public Texture2D Texture { get; set; }
        #endregion

        #region Constuctors

        public Animation(Texture2D texture, int frameCount)
        {
            this.Texture = texture;
            this.FrameCount = frameCount;
            this.FrameSpeed = 0.1f;
        }
        #endregion
    }
}
