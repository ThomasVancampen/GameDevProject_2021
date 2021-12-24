using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject_2021.Model
{
    class InputKeys
    {
        #region Var and Prop
        //Deze manier van werken hebben we opgepikt in een video op youtube
        //https://www.youtube.com/watch?v=CV8P9aq2gQo&list=PLV27bZtgVIJqoeHrQq6Mt_S1-Fvq_zzGZ&index=9
        public Keys Left { get; set; }
        public Keys Right { get; set; }
        public Keys Up { get; set; }
        public Keys Down { get; set; }
        #endregion
    }
}
