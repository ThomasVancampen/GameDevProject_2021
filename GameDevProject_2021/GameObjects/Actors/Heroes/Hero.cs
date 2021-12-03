﻿using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.Interfaces;
using GameDevProject_2021.Movement;
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
        #endregion

        #region Constructors
        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.Texture = texture;
            this._movementManager = new MovementManager();
            this.InputReader = inputReader;
            this.Speed = 4;
            this.MaxJumpHeight = -14;
            this.Gravity = 1;
            this.IsFalling = true;
            this.FallHeight = 0;
        }
        public Hero(Dictionary<string, Animation> animations, IInputReader inputReader)
        {
            this.Animations = animations;
            this.AnimationManager = new AnimationManager(Animations.First().Value);
            this._movementManager = new MovementManager();
            this.InputReader = inputReader;
            this.Speed = 4;
            this.MaxJumpHeight = -14;
            this.Gravity = 1;
            this.IsFalling = true;
            this.FallHeight = 0;
        }
        #endregion

        #region Methods

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            base.Update(gameTime, gameObjects);
            Move(gameObjects);

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
            AnimationManager.Update(gameTime);
        }

        public void Move(List<GameObject> gameObjects)
        {
            _movementManager.Move(this, gameObjects);
        }
        #endregion
    }
}