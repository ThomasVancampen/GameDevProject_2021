using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Model.Animation1
{
    public class AnimationFrame//Deze klasse mag verwijderd worden
    {
        #region Var and Prop
        public Rectangle RectangleSource { get; set; }

        #endregion

        #region Constructor
        public AnimationFrame(Rectangle rectangle)
        {
            this.RectangleSource = rectangle;
        }
        #endregion
    }
}
