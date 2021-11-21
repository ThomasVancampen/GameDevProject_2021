using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Animation
{
    public class Animate
    {
        public AnimationFrame CurrentFrame { get; set; }

        private List<AnimationFrame> frames;

        private int counter;

        private double secondCounter;
        private int fps = 15;//hier gezet in de plaats van in update

        public Animate()
        {
            this.frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            this.frames.Add(animationFrame);
            this.CurrentFrame = this.frames[0];
        }

        public void Update(GameTime gameTime)
        {
            this.CurrentFrame = this.frames[this.counter];

            this.secondCounter += gameTime.ElapsedGameTime.TotalSeconds;

            if (this.secondCounter >= 1d / fps)
            {
                this.counter++;
                this.secondCounter = 0;
            }


            if (this.counter >= this.frames.Count)
                this.counter = 0;
        }
    }
}
