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

namespace GameDevProject_2021.GameObjects.Actors.Heroes
{
    class Hero : Actor, IGameObject, IJumpable, IControllable
    {
        #region Var and Prop
        public InputKeys InputKeys { get; set; }
        public int Gravity { get; set; }
        public int JumpHeight { get; set; }
        public bool Jump { get; set; } = false;
        public bool IsFalling { get; set; }
        public int MaxJumpHeight { get; set; }
        public IInputReader InputReader { get; set; }
        public int FallHeight { get; set; }
        public int Lives { get; set; }
        public CollisionManager CollisionManager { get; set; }
        #endregion

        #region Constructors
        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.Texture = texture;
            this._movementManager = new MovementManager();
            this.InputReader = inputReader;
        }
        public Hero(Dictionary<string, Animation> animations, IInputReader inputReader)
        {
            this.Animations = animations;
            this.AnimationManager = new AnimationManager(Animations.First().Value);
            this._movementManager = new MovementManager();
            this.InputReader = inputReader;
            this.CollisionManager = new CollisionManager();
        }
        #endregion

        #region Methods

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            base.Update(gameTime, gameObjects);
            Move(gameObjects);
        }

        public void Move(List<GameObject> gameObjects)
        {
            _movementManager.Move(this, gameObjects);
        }
        #endregion
    }
}
