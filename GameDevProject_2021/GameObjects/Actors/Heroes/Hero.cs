using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject_2021.Model;
using System.Linq;
using GameDevProject_2021.Managers.Collision;

namespace GameDevProject_2021.GameObjects.Actors.Heroes
{
    abstract class Hero : Actor, IGameObject, IJumpable, IControllable
    {
        #region Var and Prop
        public InputKeys InputKeys { get; set; }
        public int Gravity { get; set; }
        public int JumpHeight { get; set; }
        public bool IsJumping { get; set; } = false;
        public bool IsFalling { get; set; }
        public int MaxJumpHeight { get; set; }
        public IInputReader InputReader { get; set; }
        public int FallHeight { get; set; }
        public int Lives { get; set; }
        public bool Hit { get; set; }
        public int InvincibleTime { get; set; }
        public int InvincibleStartTimer { get; set; }
        public bool Victorious { get; set; }
        public ICollideable CollisionManager { get; set; }
        public CollisionDetectionManager CollisionDetectionManager { get; set; }

        #endregion

        #region Constructor
        public Hero(Dictionary<string, Animation> animations, IInputReader inputReader)
        {
            InitializeHero(animations, inputReader);
        }
        #endregion

        #region Methods
        private void InitializeHero(Dictionary<string, Animation> animations, IInputReader inputReader)
        {
            this.Animations = animations;
            this.AnimationManager = new AnimationManager(Animations.First().Value);
            this.CollisionDetectionManager = new CollisionDetectionManager();
            this.InputReader = inputReader;
            this.IsFalling = true;
            this.Victorious = false;
            this.Hit = false;

        }
        #endregion
    }
}
