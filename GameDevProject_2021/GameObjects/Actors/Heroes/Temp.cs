using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameDevProject_2021.GameObjects.Actors.Heroes
{
    class Temp : Hero
    {
        public Temp(Texture2D texture, IInputReader inputReader) : base(texture, inputReader)
        {
            
            this.Speed = 4;
            this.MaxJumpHeight = -14;
            this.Gravity = 1;
            this.IsFalling = true;
            this.FallHeight = 0;
            this.Lives = 1;
        }
        public Temp(Dictionary<string, Animation> animations, IInputReader inputReader) : base(animations, inputReader)
        {
            this.Speed = 4;
            this.MaxJumpHeight = -14;
            this.Gravity = 1;
            this.IsFalling = true;
            this.FallHeight = 0;
            this.Lives = 1;
        }
        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            this.CollisionRectangle = new Rectangle((int)Position.X + AnimationManager.Animation.FrameWidth - 19, (int)Position.Y + AnimationManager.Animation.FrameHeight, 32, 32);
            base.Update(gameTime, gameObjects);

            if (Movement.X == 0 && Movement.Y == 0)//TODO: checks moeten beter eventueel jump er in vermengen
            {
                AnimationManager.Play(Animations["Idle"]);
            }
            else if (Movement.Y != 0)
            {
                AnimationManager.Play(Animations["Jump"]);
            }
            else if (Movement.X != 0)
            {
                AnimationManager.Play(Animations["Walk"]);
            }
            Position += Movement;
            Movement = Vector2.Zero;
            if (gameTime.TotalGameTime.Seconds%10==9)
            {
                this.Lives--;
            }
            if (this.Lives <=0)
            {
                this.IsAlive = false;
            }
            AnimationManager.Update(gameTime);
        }
    }
}
