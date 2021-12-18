using GameDevProject_2021.Model.Animation1;
using GameDevProject_2021.Managers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject_2021.Managers.Collision;
using GameDevProject_2021.Interfaces;

namespace GameDevProject_2021.GameObjects.Actors.Enemies
{
    abstract class ShootingEnemy : Enemy
    {
        #region prop and var
        public float RunDistance { get; set; }
        public float RunDistanceCounter { get; set; }

        public bool IsShooting { get; set; }
        public int ShootingTimer { get; set; }
        public bool IsGoingRight { get; set; }

        protected Texture2D _bulletTexture;

        public List<TreeElfBullet> Bullets { get; set; }
        public ICollideable CollisionManager { get; set; }
        public CollisionDetectionManager CollisionDetectionManager { get; set; }
        public bool CanMove { get; set; }
        #endregion

        #region constructors
        public ShootingEnemy(Dictionary<string, Animation> animations, Texture2D bulletTexture)
        {
            InitializeShootingEnemy(animations, bulletTexture);
        }
        #endregion

        #region methods
        private void InitializeShootingEnemy(Dictionary<string, Animation> animations, Texture2D bulletTexture)
        {
            this.Animations = animations;
            this.AnimationManager = new AnimationManager(Animations.First().Value);
            this._movementManager = new MovementManager();
            this.IsShooting = false;
            this._bulletTexture = bulletTexture;
            this.IsGoingRight = true;
            this.CollisionDetectionManager = new CollisionDetectionManager();
            this.CanMove = true;

        }
        #endregion
    }
}
